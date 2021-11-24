using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EasyAbp.PaymentService.Installment.RepaymentRecords
{
    public static class RepaymentRecordEfCoreQueryableExtensions
    {
        public static IQueryable<RepaymentRecord> IncludeDetails(this IQueryable<RepaymentRecord> queryable, bool include = true)
        {
            if (!include)
            {
                return queryable;
            }

            return queryable
                // .Include(x => x.xxx) // TODO: AbpHelper generated
                ;
        }
    }
}