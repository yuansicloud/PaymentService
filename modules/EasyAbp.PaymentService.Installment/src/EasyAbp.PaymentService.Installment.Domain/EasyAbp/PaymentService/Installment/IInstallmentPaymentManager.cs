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
    public class IInstallmentPaymentManager : DomainService
    {
        private readonly IInstallmentRecordRepository _installmentRecordRepository;

        private readonly IPaymentRepository _paymentRepository;

        private readonly IPaymentManager _paymentManager;

        private readonly IGuidGenerator _guidGenerator;

        public IInstallmentPaymentManager(IInstallmentRecordRepository installmentRecordRepository, IPaymentRepository paymentRepository, IGuidGenerator guidGenerator, IPaymentManager paymentManager)
        {
            _installmentRecordRepository = installmentRecordRepository;
            _paymentRepository = paymentRepository;
            _guidGenerator = guidGenerator;
            _paymentManager = paymentManager;
        }

        public async Task<InstallmentRecord> CreateInstallment(Guid paymentId, decimal amount)
        {
            var payment = await _paymentRepository.GetAsync(paymentId);

            if (payment.IsCompleted())
            {
                throw new BusinessException();
            }

            var installments = _installmentRecordRepository.Where(x => x.PaymentId == paymentId);

            decimal currentPaidAmount = installments.Sum(x => x.PaymentAmount);

            if (currentPaidAmount + amount > payment.OriginalPaymentAmount)
            {
                throw new BusinessException();
            }

            var record = await _installmentRecordRepository.InsertAsync(new InstallmentRecord(_guidGenerator.Create(), payment.TenantId, paymentId, amount), true);

            if (currentPaidAmount + amount == payment.OriginalPaymentAmount)
            {
                await _paymentManager.CompletePaymentAsync(payment);
            }

            return record;
        }
    }
}