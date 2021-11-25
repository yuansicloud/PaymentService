using EasyAbp.PaymentService.Installment.InstallmentRecords;
using EasyAbp.PaymentService.Payments;
using EasyAbp.PaymentService.Refunds;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Data;
using Volo.Abp.Guids;
using Volo.Abp.MultiTenancy;

namespace EasyAbp.PaymentService.Installment
{
    public class InstallmentPaymentServiceProvider : PaymentServiceProvider
    {
        public const string PaymentMethod = "Installment";

        private readonly IPaymentRepository _paymentRepository;

        private readonly IInstallmentRecordRepository _installmentRecordRepository;

        private readonly IGuidGenerator _guidGenerator;

        private readonly ICurrentTenant _currentTenant;

        private readonly IPaymentManager _paymentManager;

        public InstallmentPaymentServiceProvider(IPaymentRepository paymentRepository, IInstallmentRecordRepository installmentRecordRepository, IGuidGenerator guidGenerator, ICurrentTenant currentTenant, IPaymentManager paymentManager)
        {
            _paymentRepository = paymentRepository;
            _installmentRecordRepository = installmentRecordRepository;
            _guidGenerator = guidGenerator;
            _currentTenant = currentTenant;
            _paymentManager = paymentManager;
        }

        public override async Task OnPaymentStartedAsync(Payment payment, ExtraPropertyDictionary configurations)
        {
            if (payment.Currency != "CNY")
            {
                throw new CurrencyNotSupportedException(payment.PaymentMethod, payment.Currency);
            }

            if (payment.ActualPaymentAmount <= decimal.Zero)
            {
                throw new PaymentAmountInvalidException(payment.ActualPaymentAmount, PaymentMethod);
            }

            var paymentTime = configurations.GetOrDefault("PaymentTime") as DateTime? ??
                               DateTime.Now;

            if (await _installmentRecordRepository.FindAsync(x => x.PaymentId == payment.Id) != null)
            {
                throw new UserFriendlyException("Payment already started");
            }

            await _installmentRecordRepository.InsertAsync(new InstallmentRecord(_guidGenerator.Create(), _currentTenant.Id, payment.Id, payment.ActualPaymentAmount, 0, payment.ActualPaymentAmount, paymentTime, payment.UserId));
        }

        public override async Task OnCancelStartedAsync(Payment payment)
        {
            var installment = await _installmentRecordRepository.FindAsync(x => x.PaymentId == payment.Id);

            if (installment == null)
            {
                throw new UserFriendlyException("Installment not exist");
            }

            installment.CancelPayment(DateTime.Now);

            await _installmentRecordRepository.UpdateAsync(installment);

            await _paymentManager.CompleteCancelAsync(payment);
        }

        public override async Task OnRefundStartedAsync(Payment payment, Refund refund)
        {
            await _paymentManager.CompleteRefundAsync(payment, refund);
        }
    }
}
