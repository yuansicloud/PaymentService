using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace EasyAbp.PaymentService.Installment
{
    [DependsOn(
        typeof(InstallmentDomainSharedModule),
        typeof(AbpDddApplicationContractsModule),
        typeof(AbpAuthorizationModule)
        )]
    public class InstallmentApplicationContractsModule : AbpModule
    {

    }
}
