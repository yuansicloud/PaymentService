using System;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace EasyAbp.PaymentService.Installment.RepaymentRecords
{
    public class RepaymentRecord : AuditedEntity<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; protected set; }

        public virtual decimal PaymentAmount { get; protected set; } 

        public virtual DateTime PaymentTime { get; protected set; }

        protected RepaymentRecord()
        {
        }

        public RepaymentRecord(
            Guid id,
            Guid? tenantId,
            decimal paymentAmount,
            DateTime paymentTime
        ) : base(id)
        {
            TenantId = tenantId;
            PaymentAmount = paymentAmount;
            PaymentTime = paymentTime;
        }
    }
}
