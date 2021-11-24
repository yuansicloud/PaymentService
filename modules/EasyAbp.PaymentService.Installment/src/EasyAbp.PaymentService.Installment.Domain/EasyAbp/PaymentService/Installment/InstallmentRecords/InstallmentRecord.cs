using EasyAbp.PaymentService.Installment.RepaymentRecords;
using EasyAbp.PaymentService.Payments;
using System;
using System.Collections.Generic;
using System.Linq;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace EasyAbp.PaymentService.Installment.InstallmentRecords
{
    public class InstallmentRecord : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; protected set; }

        public virtual Guid UserId { get; protected set;  }

        public virtual Guid PaymentId { get; protected set; }

        public virtual decimal OriginalPaymentAmount { get; protected set; }

        public virtual decimal PaymentDiscount { get; protected set; }

        public virtual decimal ActualPaymentAmount { get; protected set; }

        public virtual DateTime PaymentTime { get; protected set; }

        public virtual DateTime? CompletionTime { get; protected set; }

        public virtual DateTime? CanceledTime { get; protected set; }

        public virtual ICollection<RepaymentRecord> RepaymentRecords { get; protected set; }

        protected InstallmentRecord()
        {
            RepaymentRecords = new List<RepaymentRecord>();
        }


        public InstallmentRecord(
            Guid id,
            Guid? tenantId,
            Guid paymentId,
            decimal originalPaymentAmount,
            decimal paymentDiscount,
            decimal actualPaymentAmount,
            DateTime paymentTime,
            Guid userId) : base(id)
        {
            TenantId = tenantId;
            PaymentId = paymentId;
            OriginalPaymentAmount = originalPaymentAmount;
            PaymentDiscount = paymentDiscount;
            ActualPaymentAmount = actualPaymentAmount;
            PaymentTime = paymentTime;
            RepaymentRecords = new List<RepaymentRecord>();
            UserId = userId;
        }

        public void SetPaymentDiscount(decimal paymentDiscount)
        {
            CheckIsInProgress();

            PaymentDiscount = paymentDiscount;
            ActualPaymentAmount = (OriginalPaymentAmount - paymentDiscount).EnsureIsNonNegative();
        }

        public void CompletePayment(DateTime completionTime)
        {
            CheckIsInProgress();

            CompletionTime = completionTime;
        }

        public void CancelPayment(DateTime canceledTime)
        {
            //CheckIsInProgress();

            CanceledTime = canceledTime;
        }

        public bool IsCanceled()
        {
            return CanceledTime.HasValue;
        }

        public bool IsCompleted()
        {
            return CompletionTime.HasValue;
        }

        public bool IsInProgress()
        {
            return !IsCanceled() && !IsCompleted();
        }

        public void RemoveRepaymentRecord(RepaymentRecord item)
        {
            CheckIsInProgress();

            RepaymentRecords.Remove(item);
        }

        public void AddRepaymentRecord(RepaymentRecord item)
        {
            CheckIsInProgress();

            RepaymentRecords.Add(item);
        }

        public decimal PaidAmount()
        {
            return RepaymentRecords?.ToList().Sum(x => x.PaymentAmount) ?? 0;
        }

        public decimal DebtAmount()
        {
            return ActualPaymentAmount - PaidAmount();
        }

        public RepaymentRecord GetRepayment(Guid repaymentId)
        {
            return RepaymentRecords.SingleOrDefault(x => x.Id == repaymentId);
        }

        private void CheckIsInProgress()
        {
            if (!IsInProgress())
            {
                throw new PaymentIsInUnexpectedStageException(Id);
            }
        }

    }
}
