using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace EasyAbp.PaymentService.Installment
{
    [DependsOn(
        typeof(PaymentServiceInstallmentApplicationContractsModule),
        typeof(AbpHttpClientModule))]
    public class PaymentServiceInstallmentHttpApiClientModule : AbpModule
    {
        public const string RemoteServiceName = "Installment";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(PaymentServiceInstallmentApplicationContractsModule).Assembly,
                RemoteServiceName
            );
        }
    }
}
