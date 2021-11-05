using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace EasyAbp.PaymentService.Installment
{
    [DependsOn(
        typeof(InstallmentApplicationContractsModule),
        typeof(AbpHttpClientModule))]
    public class InstallmentHttpApiClientModule : AbpModule
    {
        public const string RemoteServiceName = "Installment";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(InstallmentApplicationContractsModule).Assembly,
                RemoteServiceName
            );
        }
    }
}
