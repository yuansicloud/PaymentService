using System;
using Volo.Abp.Application.Dtos;

namespace EasyAbp.PaymentService.Installment.InstallmentRecords.Dtos
{
    [Serializable]
    public class InstallmentRecordDto : CreationAuditedEntityDto<Guid>
    {
        public Guid PaymentId { get; set; }

        public decimal PaymentAmount { get; set; }
    }
}