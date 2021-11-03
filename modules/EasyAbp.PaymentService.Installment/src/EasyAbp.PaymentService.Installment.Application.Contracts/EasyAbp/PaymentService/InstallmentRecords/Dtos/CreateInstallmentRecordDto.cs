using System;
using System.ComponentModel;
namespace EasyAbp.PaymentService.Installment.InstallmentRecords.Dtos
{
    [Serializable]
    public class CreateInstallmentRecordDto
    {
        [DisplayName("InstallmentRecordPaymentId")]
        public Guid PaymentId { get; set; }

        [DisplayName("InstallmentRecordPaymentAmount")]
        public decimal PaymentAmount { get; set; }
    }
}