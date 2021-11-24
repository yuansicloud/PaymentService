using System;
using EasyAbp.PaymentService.Installment.Permissions;
using EasyAbp.PaymentService.Installment.InstallmentRecords.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using System.Threading.Tasks;
using System.Linq;
using Volo.Abp.Domain.Repositories;

namespace EasyAbp.PaymentService.Installment.InstallmentRecords
{
    public class InstallmentRecordAppService : ReadOnlyAppService<InstallmentRecord, InstallmentRecordDto, Guid, GetInstallmentListInput>,
        IInstallmentRecordAppService
    {
        protected override string GetPolicyName { get; set; } = InstallmentPermissions.InstallmentRecord.Default;
        protected override string GetListPolicyName { get; set; } = InstallmentPermissions.InstallmentRecord.Default;

        private readonly IInstallmentRecordRepository _repository;

        private readonly InstallmentPaymentManager _installmentPaymentManager;

        public InstallmentRecordAppService(
            IInstallmentRecordRepository repository, 
            InstallmentPaymentManager installmentPaymentManager) : base(repository)
        {
            _repository = repository;
            _installmentPaymentManager = installmentPaymentManager;
        }

        public async Task<InstallmentRecordDto> GetByPaymentId(Guid paymentId)
        {
            var installment = await _repository.SingleOrDefaultAsync(x => x.PaymentId == paymentId);

            return await MapToGetOutputDtoAsync(installment);
        }

        public async Task RepayAsync(Guid id, RepayInput input)
        {
            var installment = await _repository.GetAsync(id);

            await _installmentPaymentManager.RepayAsync(installment, input.PaymentAmount, input.PaymentTime);
        }

        public async Task RemoveRepaymentAsync(Guid id, RemoveRepaymentInput input)
        {
            var installment = await _repository.GetAsync(id);

            var repayment = installment.GetRepayment(input.RepaymentId);

            installment.RemoveRepaymentRecord(repayment);

            await _repository.UpdateAsync(installment);
        }

        protected override async Task<IQueryable<InstallmentRecord>> CreateFilteredQueryAsync(GetInstallmentListInput input)
        {
            var query = await _repository.WithDetailsAsync();

            query = query
                .WhereIf(input.PaymentId.HasValue, q => q.PaymentId == input.PaymentId.Value)
                .WhereIf(input.MinCreationTime.HasValue, x => x.CreationTime >= input.MinCreationTime.Value)
                .WhereIf(input.MaxCreationTime.HasValue, x => x.CreationTime <= input.MaxCreationTime.Value)
                .WhereIf(input.MinPaymentTime.HasValue, x => x.PaymentTime >= input.MinPaymentTime.Value)
                .WhereIf(input.MaxPaymentTime.HasValue, x => x.PaymentTime <= input.MaxPaymentTime.Value)
                .WhereIf(input.UserId.HasValue, x => x.UserId == input.UserId.Value)
                .WhereIf(input.MinActualPaymentAmount.HasValue, x => x.ActualPaymentAmount >= input.MinActualPaymentAmount.Value)
                .WhereIf(input.MaxActualPaymentAmount.HasValue, x => x.ActualPaymentAmount <= input.MaxActualPaymentAmount.Value);

            return query;
        }

    }
}
