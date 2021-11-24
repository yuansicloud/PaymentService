using System;
using EasyAbp.PaymentService.Installment.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace EasyAbp.PaymentService.Installment.RepaymentRecords
{
    public class RepaymentRecordRepository : EfCoreRepository<IInstallmentDbContext, RepaymentRecord, Guid>, IRepaymentRecordRepository
    {
        public RepaymentRecordRepository(IDbContextProvider<IInstallmentDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}