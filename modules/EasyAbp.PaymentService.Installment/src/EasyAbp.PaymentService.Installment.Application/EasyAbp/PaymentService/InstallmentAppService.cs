using EasyAbp.PaymentService.Installment.Localization;
using Volo.Abp.Application.Services;

namespace EasyAbp.PaymentService.Installment
{
    public abstract class InstallmentAppService : ApplicationService
    {
        protected InstallmentAppService()
        {
            LocalizationResource = typeof(InstallmentResource);
            ObjectMapperContext = typeof(PaymentServiceInstallmentApplicationModule);
        }
    }
}
