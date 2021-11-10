using System;
using EasyAbp.PaymentService.Installment.Permissions;
using EasyAbp.PaymentService.Installment.InstallmentRecords.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using System.Threading.Tasks;
using System.Linq;

namespace EasyAbp.PaymentService.Installment.InstallmentRecords
{
    public class InstallmentRecordAppService : CrudAppService<InstallmentRecord, InstallmentRecordDto, Guid, GetInstallmentListInput, CreateInstallmentRecordDto, UpdateInstallmentRecordDto>,
        IInstallmentRecordAppService
    {
        protected override string GetPolicyName { get; set; } = InstallmentPermissions.InstallmentRecord.Default;
        protected override string GetListPolicyName { get; set; } = InstallmentPermissions.InstallmentRecord.Default;
        protected override string CreatePolicyName { get; set; } = InstallmentPermissions.InstallmentRecord.Create;
        protected override string UpdatePolicyName { get; set; } = InstallmentPermissions.InstallmentRecord.Update;
        protected override string DeletePolicyName { get; set; } = InstallmentPermissions.InstallmentRecord.Delete;

        private readonly IInstallmentRecordRepository _repository;

        private readonly IInstallmentPaymentManager _installmentPaymentManager;

        public InstallmentRecordAppService(
            IInstallmentRecordRepository repository, 
            IInstallmentPaymentManager installmentPaymentManager) : base(repository)
        {
            _repository = repository;
            _installmentPaymentManager = installmentPaymentManager;
        }

        public override async Task<InstallmentRecordDto> CreateAsync(CreateInstallmentRecordDto input)
        {
            return await MapToGetOutputDtoAsync(await _installmentPaymentManager.CreateInstallment(input.PaymentId, input.PaymentAmount, input.PaymentTime));
        }

        protected override async Task<IQueryable<InstallmentRecord>> CreateFilteredQueryAsync(GetInstallmentListInput input)
        {
            var query = await _repository.WithDetailsAsync();

            query = query
                .WhereIf(input.PaymentId.HasValue, q => q.PaymentId == input.PaymentId.Value)
                .WhereIf(input.MinCreationTime.HasValue, x => x.CreationTime >= input.MinCreationTime.Value)
                .WhereIf(input.MaxCreationTime.HasValue, x => x.CreationTime <= input.MaxCreationTime.Value)
                .WhereIf(input.MinPaymentTime.HasValue, x => x.PaymentTime >= input.MinPaymentTime.Value)
                .WhereIf(input.MaxPaymentTime.HasValue, x => x.PaymentTime <= input.MaxPaymentTime.Value);

            return query;
        }

    }
}
