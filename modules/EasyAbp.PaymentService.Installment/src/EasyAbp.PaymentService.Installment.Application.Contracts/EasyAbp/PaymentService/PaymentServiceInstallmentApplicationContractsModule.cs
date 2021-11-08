using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace EasyAbp.PaymentService.Installment
{
    [DependsOn(
        typeof(PaymentServiceInstallmentDomainSharedModule),
        typeof(AbpDddApplicationContractsModule),
        typeof(AbpAuthorizationModule)
        )]
    public class PaymentServiceInstallmentApplicationContractsModule : AbpModule
    {

    }
}
