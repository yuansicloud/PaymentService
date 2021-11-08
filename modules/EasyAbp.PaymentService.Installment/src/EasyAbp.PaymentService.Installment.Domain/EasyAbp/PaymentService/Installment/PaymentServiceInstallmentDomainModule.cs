using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace EasyAbp.PaymentService.Installment
{
    [DependsOn(
        typeof(AbpDddDomainModule),
        typeof(PaymentServiceInstallmentDomainSharedModule)
    )]
    public class PaymentServiceInstallmentDomainModule : AbpModule
    {

    }
}
