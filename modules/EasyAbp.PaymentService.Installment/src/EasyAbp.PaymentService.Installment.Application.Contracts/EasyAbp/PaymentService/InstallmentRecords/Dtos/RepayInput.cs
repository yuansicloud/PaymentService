using System;
using System.ComponentModel;
namespace EasyAbp.PaymentService.Installment.InstallmentRecords.Dtos
{
    [Serializable]
    public class RepayInput
    {

        public decimal PaymentAmount { get; set; }

        public DateTime PaymentTime { get; set; }
    }
}