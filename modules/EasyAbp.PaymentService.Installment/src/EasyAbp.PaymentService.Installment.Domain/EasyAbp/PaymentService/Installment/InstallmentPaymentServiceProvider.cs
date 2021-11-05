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

        private readonly IPaymentRepository _paymentRepository;

        public InstallmentPaymentServiceProvider(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public override async Task OnPaymentStartedAsync(Payment payment, ExtraPropertyDictionary configurations)
        {
            if (payment.Currency != "CNY")
            {
                throw new CurrencyNotSupportedException(payment.PaymentMethod, payment.Currency);
            }

            if (payment.ActualPaymentAmount <= decimal.Zero)
            {
                throw new PaymentAmountInvalidException(payment.ActualPaymentAmount, PaymentMethod);
            }

            //await _paymentRepository.UpdateAsync(payment, true);
        }
    }
}
