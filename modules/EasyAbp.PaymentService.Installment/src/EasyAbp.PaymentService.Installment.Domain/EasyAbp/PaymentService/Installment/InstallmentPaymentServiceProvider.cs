using EasyAbp.PaymentService.Installment.InstallmentRecords;
using EasyAbp.PaymentService.Payments;
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

        public InstallmentPaymentServiceProvider(IPaymentRepository paymentRepository, IInstallmentRecordRepository installmentRecordRepository, IGuidGenerator guidGenerator, ICurrentTenant currentTenant)
        {
            _paymentRepository = paymentRepository;
            _installmentRecordRepository = installmentRecordRepository;
            _guidGenerator = guidGenerator;
            _currentTenant = currentTenant;
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
    }
}
