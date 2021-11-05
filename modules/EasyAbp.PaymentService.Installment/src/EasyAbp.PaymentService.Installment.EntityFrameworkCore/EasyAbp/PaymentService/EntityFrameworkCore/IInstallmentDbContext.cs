using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using EasyAbp.PaymentService.Installment.InstallmentRecords;

namespace EasyAbp.PaymentService.Installment.EntityFrameworkCore
{
    [ConnectionStringName(InstallmentDbProperties.ConnectionStringName)]
    public interface IInstallmentDbContext : IEfCoreDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * DbSet<Question> Questions { get; }
         */
        DbSet<InstallmentRecord> InstallmentRecords { get; set; }
    }
}
