using System;
using Volo.Abp.Domain.Repositories;

namespace EasyAbp.PaymentService.Installment.RepaymentRecords
{
    public interface IRepaymentRecordRepository : IRepository<RepaymentRecord, Guid>
    {
    }
}