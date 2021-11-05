using EasyAbp.PaymentService.Installment.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace EasyAbp.PaymentService.Installment
{
    /* Domain tests are configured to use the EF Core provider.
     * You can switch to MongoDB, however your domain tests should be
     * database independent anyway.
     */
    [DependsOn(
        typeof(InstallmentEntityFrameworkCoreTestModule)
        )]
    public class InstallmentDomainTestModule : AbpModule
    {
        
    }
}
