using System;
using Volo.Abp.Application.Dtos;

namespace EasyAbp.PaymentService.Installment.InstallmentRecords.Dtos
{
    public class RepaymentRecordDto : AuditedEntityDto<Guid>
    {
        public decimal PaymentAmount { get; set; }

        public DateTime PaymentTime { get; set; }
    }
}
