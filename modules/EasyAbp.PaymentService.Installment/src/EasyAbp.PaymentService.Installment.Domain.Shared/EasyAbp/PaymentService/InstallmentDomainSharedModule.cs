using Volo.Abp.Modularity;
using Volo.Abp.Localization;
using EasyAbp.PaymentService.Installment.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Validation;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;

namespace EasyAbp.PaymentService.Installment
{
    [DependsOn(
        typeof(AbpValidationModule)
    )]
    public class InstallmentDomainSharedModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<InstallmentDomainSharedModule>();
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Add<InstallmentResource>("en")
                    .AddBaseTypes(typeof(AbpValidationResource))
                    .AddVirtualJson("/EasyAbp/PaymentService/Localization/Installment");
            });

            Configure<AbpExceptionLocalizationOptions>(options =>
            {
                options.MapCodeNamespace("EasyAbp.PaymentService.Installment", typeof(InstallmentResource));
            });
        }
    }
}
