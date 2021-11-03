using System;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace EasyAbp.PaymentService.Installment.InstallmentRecords
{
    public class InstallmentRecord : CreationAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; protected set; }

        public virtual Guid PaymentId { get; protected set; }

        public virtual decimal PaymentAmount { get; protected set; }


        protected InstallmentRecord()
        {
        }

        public InstallmentRecord(
            Guid id,
            Guid? tenantId,
            Guid paymentId,
            decimal paymentAmount
        ) : base(id)
        {
            TenantId = tenantId;
            PaymentId = paymentId;
            PaymentAmount = paymentAmount;
        }
    }
}
