using EasyAbp.PaymentService.Installment.InstallmentRecords.Dtos;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace EasyAbp.PaymentService.Installment.InstallmentRecords
{
    public interface IInstallmentRecordAppService :
        IReadOnlyAppService< 
            InstallmentRecordDto, 
            Guid, 
            GetInstallmentListInput>
    {
        Task RepayAsync(Guid id, RepayInput input);

        Task RemoveRepaymentAsync(Guid id, RemoveRepaymentInput input);

        Task<InstallmentRecordDto> GetByPaymentIdAsync(Guid paymentId);

        Task<InstallmentRecordDto> CancelAsync(Guid id);
    }
}