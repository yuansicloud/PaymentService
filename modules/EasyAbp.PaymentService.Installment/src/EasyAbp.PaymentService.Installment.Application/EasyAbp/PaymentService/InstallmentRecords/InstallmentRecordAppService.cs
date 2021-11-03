using System;
using EasyAbp.PaymentService.Installment.Permissions;
using EasyAbp.PaymentService.Installment.InstallmentRecords.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace EasyAbp.PaymentService.Installment.InstallmentRecords
{
    public class InstallmentRecordAppService : CrudAppService<InstallmentRecord, InstallmentRecordDto, Guid, PagedAndSortedResultRequestDto, CreateInstallmentRecordDto, UpdateInstallmentRecordDto>,
        IInstallmentRecordAppService
    {
        protected override string GetPolicyName { get; set; } = InstallmentPermissions.InstallmentRecord.Default;
        protected override string GetListPolicyName { get; set; } = InstallmentPermissions.InstallmentRecord.Default;
        protected override string CreatePolicyName { get; set; } = InstallmentPermissions.InstallmentRecord.Create;
        protected override string UpdatePolicyName { get; set; } = InstallmentPermissions.InstallmentRecord.Update;
        protected override string DeletePolicyName { get; set; } = InstallmentPermissions.InstallmentRecord.Delete;

        private readonly IInstallmentRecordRepository _repository;
        
        public InstallmentRecordAppService(IInstallmentRecordRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
