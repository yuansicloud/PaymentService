using System;
using System.Collections.Generic;
using System.Linq;
using Volo.Abp.Application.Dtos;

namespace EasyAbp.PaymentService.Installment.InstallmentRecords.Dtos
{
    [Serializable]
    public class InstallmentRecordDto : FullAuditedEntityDto<Guid>
    {
        public Guid UserId { get; set; }

        public Guid PaymentId { get; set; }

        public decimal OriginalPaymentAmount { get; set; }

        public decimal PaymentDiscount { get; set; }

        public decimal ActualPaymentAmount { get; set; }

        public DateTime PaymentTime { get; set; }

        public DateTime? CompletionTime { get; set; }

        public DateTime? CanceledTime { get; set; }

        public List<RepaymentRecordDto> RepaymentRecords { get; set; }

        public decimal DebtAmount
        {
            get
            {
                return ActualPaymentAmount - PaidAmount;
            }
        }

        public decimal PaidAmount
        {
            get
            {
                return RepaymentRecords?.Sum(x => x.PaymentAmount) ?? 0;
            }
        }
    }
}