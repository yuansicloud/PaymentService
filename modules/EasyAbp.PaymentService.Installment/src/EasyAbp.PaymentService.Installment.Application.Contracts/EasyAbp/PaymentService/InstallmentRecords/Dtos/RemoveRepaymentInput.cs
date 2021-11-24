using System;
using System.Collections.Generic;
using System.Text;

namespace EasyAbp.PaymentService.Installment.InstallmentRecords.Dtos
{
    public class RemoveRepaymentInput
    {
        public Guid RepaymentId { get; set; }
    }
}
