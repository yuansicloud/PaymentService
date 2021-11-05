using Volo.Abp.Modularity;

namespace EasyAbp.PaymentService.Installment
{
    [DependsOn(
        typeof(InstallmentApplicationModule),
        typeof(InstallmentDomainTestModule)
        )]
    public class InstallmentApplicationTestModule : AbpModule
    {

    }
}
