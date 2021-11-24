using System;
using System.Linq;
using System.Threading.Tasks;
using EasyAbp.PaymentService.Installment.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace EasyAbp.PaymentService.Installment.InstallmentRecords
{
    public class InstallmentRecordRepository : EfCoreRepository<IInstallmentDbContext, InstallmentRecord, Guid>, IInstallmentRecordRepository
    {
        public InstallmentRecordRepository(IDbContextProvider<IInstallmentDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public override async Task<IQueryable<InstallmentRecord>> WithDetailsAsync()
        {
            return (await base.WithDetailsAsync()).IncludeDetails();
        }
    }
}