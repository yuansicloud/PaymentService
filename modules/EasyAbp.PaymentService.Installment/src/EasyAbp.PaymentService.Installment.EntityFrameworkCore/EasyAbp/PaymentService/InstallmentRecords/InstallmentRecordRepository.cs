using System;
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
    }
}