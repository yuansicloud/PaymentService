using System;
using Volo.Abp.Application.Dtos;

namespace EasyAbp.PaymentService.Installment.InstallmentRecords.Dtos
{
    public class GetInstallmentListInput : PagedAndSortedResultRequestDto
    {
        public Guid? PaymentId { get; set; }

        public DateTime? MaxCreationTime { get; set; }

        public DateTime? MinCreationTime { get; set; }

        public DateTime? MaxPaymentTime { get; set; }

        public DateTime? MinPaymentTime { get; set; }
    }
}
