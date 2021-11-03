using EasyAbp.PaymentService.Payments;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;

namespace EasyAbp.PaymentService.Installment
{
    public class InstallmentPaymentServiceProvider : PaymentServiceProvider
    {
        public const string PaymentMethod = "Installment";

        public override async Task OnPaymentStartedAsync(Payment payment, ExtraPropertyDictionary configurations)
        {
            return base.OnPaymentStartedAsync(payment, configurations);
        }
    }
}
