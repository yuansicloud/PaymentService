using EasyAbp.PaymentService.Installment.InstallmentRecords;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace EasyAbp.PaymentService.Installment.EntityFrameworkCore
{
    [DependsOn(
        typeof(PaymentServiceInstallmentDomainModule),
        typeof(AbpEntityFrameworkCoreModule)
    )]
    public class PaymentServiceInstallmentEntityFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<InstallmentDbContext>(options =>
            {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, EfCoreQuestionRepository>();
                 */
                options.AddRepository<InstallmentRecord, InstallmentRecordRepository>();
            });
        }
    }
}
