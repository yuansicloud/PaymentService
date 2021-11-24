using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using EasyAbp.PaymentService.Installment.InstallmentRecords;
using EasyAbp.PaymentService.Installment.RepaymentRecords;

namespace EasyAbp.PaymentService.Installment.EntityFrameworkCore
{
    [ConnectionStringName(InstallmentDbProperties.ConnectionStringName)]
    public interface IInstallmentDbContext : IEfCoreDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * DbSet<Question> Questions { get; }
         */
        DbSet<InstallmentRecord> InstallmentRecords { get; set; }
        DbSet<RepaymentRecord> RepaymentRecords { get; set; }
    }
}
