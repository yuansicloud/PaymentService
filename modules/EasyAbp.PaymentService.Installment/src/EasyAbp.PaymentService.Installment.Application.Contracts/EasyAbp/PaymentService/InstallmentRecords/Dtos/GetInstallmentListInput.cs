using System;
using Volo.Abp.Application.Dtos;

namespace EasyAbp.PaymentService.Installment.InstallmentRecords.Dtos
{
    public class GetInstallmentListInput : PagedAndSortedResultRequestDto
    {
        public Guid? PaymentId { get; set; }
    }
}
