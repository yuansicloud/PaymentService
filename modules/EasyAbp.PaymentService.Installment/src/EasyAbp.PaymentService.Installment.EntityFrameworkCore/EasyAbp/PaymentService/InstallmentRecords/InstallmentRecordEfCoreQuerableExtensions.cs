using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EasyAbp.PaymentService.Installment.InstallmentRecords
{
    public static class InstallmentRecordEfCoreQueryableExtensions
    {
        public static IQueryable<InstallmentRecord> IncludeDetails(this IQueryable<InstallmentRecord> queryable, bool include = true)
        {
            if (!include)
            {
                return queryable;
            }

            return queryable
                 .Include(x => x.RepaymentRecords) // TODO: AbpHelper generated
                ;
        }
    }
}