using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace EasyAbp.PaymentService.Installment
{
    [DependsOn(
        typeof(InstallmentHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class InstallmentConsoleApiClientModule : AbpModule
    {
        
    }
}
