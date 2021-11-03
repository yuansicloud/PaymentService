using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace EasyAbp.PaymentService.Installment
{
    [DependsOn(
        typeof(AbpDddDomainModule),
        typeof(InstallmentDomainSharedModule)
    )]
    public class InstallmentDomainModule : AbpModule
    {

    }
}
