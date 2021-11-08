using Localization.Resources.AbpUi;
using EasyAbp.PaymentService.Installment.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace EasyAbp.PaymentService.Installment
{
    [DependsOn(
        typeof(PaymentServiceInstallmentApplicationContractsModule),
        typeof(AbpAspNetCoreMvcModule))]
    public class PaymentServiceInstallmentHttpApiModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(PaymentServiceInstallmentHttpApiModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<InstallmentResource>()
                    .AddBaseTypes(typeof(AbpUiResource));
            });
        }
    }
}
