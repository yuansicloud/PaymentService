using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.Application;

namespace EasyAbp.PaymentService.Installment
{
    [DependsOn(
        typeof(InstallmentDomainModule),
        typeof(InstallmentApplicationContractsModule),
        typeof(AbpDddApplicationModule),
        typeof(AbpAutoMapperModule)
        )]
    public class InstallmentApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<InstallmentApplicationModule>();
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<InstallmentApplicationModule>(validate: true);
            });
        }
    }
}
