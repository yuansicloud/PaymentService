using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using EasyAbp.PaymentService.Installment.InstallmentRecords;
using EasyAbp.PaymentService.Installment.RepaymentRecords;

namespace EasyAbp.PaymentService.Installment.EntityFrameworkCore
{
    [ConnectionStringName(InstallmentDbProperties.ConnectionStringName)]
    public class InstallmentDbContext : AbpDbContext<InstallmentDbContext>, IInstallmentDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * public DbSet<Question> Questions { get; set; }
         */
        public DbSet<InstallmentRecord> InstallmentRecords { get; set; }
        public DbSet<RepaymentRecord> RepaymentRecords { get; set; }

        public InstallmentDbContext(DbContextOptions<InstallmentDbContext> options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureInstallment();
        }
    }
}
