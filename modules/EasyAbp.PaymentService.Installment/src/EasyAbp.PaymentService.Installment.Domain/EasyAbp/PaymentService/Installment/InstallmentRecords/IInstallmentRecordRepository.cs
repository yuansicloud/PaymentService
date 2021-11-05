using System;
using Volo.Abp.Domain.Repositories;

namespace EasyAbp.PaymentService.Installment.InstallmentRecords
{
    public interface IInstallmentRecordRepository : IRepository<InstallmentRecord, Guid>
    {
    }
}