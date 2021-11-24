using EasyAbp.PaymentService.Installment.InstallmentRecords;
using EasyAbp.PaymentService.Payments;
using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Services;
using Volo.Abp.Guids;

namespace EasyAbp.PaymentService.Installment
{
    public class InstallmentPaymentManager : DomainService
    {
        private readonly IInstallmentRecordRepository _installmentRecordRepository;

        private readonly IPaymentRepository _paymentRepository;

        private readonly IPaymentManager _paymentManager;

        private readonly IGuidGenerator _guidGenerator;

        public InstallmentPaymentManager(IInstallmentRecordRepository installmentRecordRepository, IPaymentRepository paymentRepository, IGuidGenerator guidGenerator, IPaymentManager paymentManager)
        {
            _installmentRecordRepository = installmentRecordRepository;
            _paymentRepository = paymentRepository;
            _guidGenerator = guidGenerator;
            _paymentManager = paymentManager;
        }

        public async Task<InstallmentRecord> RepayAsync(InstallmentRecord installment, decimal paymentAmount, DateTime paymentTime)
        {

            decimal currentPaidAmount = installment.RepaymentRecords.Sum(x => x.PaymentAmount);

            if (installment.DebtAmount() < paymentAmount)
            {
                throw new UserFriendlyException("debt is less than paid amount!");
            }

            installment.AddRepaymentRecord(new RepaymentRecords.RepaymentRecord(_guidGenerator.Create(), installment.Id, paymentAmount, paymentTime));

            if (installment.DebtAmount() == 0)
            {
                var payment = await _paymentRepository.GetAsync(installment.PaymentId);

                await _paymentManager.CompletePaymentAsync(payment);

                installment.CompletePayment(paymentTime);
            }

            return installment;
        }
    }
}