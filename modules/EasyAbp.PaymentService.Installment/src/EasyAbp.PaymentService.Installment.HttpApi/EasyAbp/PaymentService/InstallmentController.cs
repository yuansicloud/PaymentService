using EasyAbp.PaymentService.Installment.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace EasyAbp.PaymentService.Installment
{
    public abstract class InstallmentController : AbpController
    {
        protected InstallmentController()
        {
            LocalizationResource = typeof(InstallmentResource);
        }
    }
}
