using System;
using System.Threading.Tasks;
using EasyAbp.PaymentService.Installment.InstallmentRecords;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace EasyAbp.PaymentService.Installment.EntityFrameworkCore.InstallmentRecords
{
    public class InstallmentRecordRepositoryTests : InstallmentEntityFrameworkCoreTestBase
    {
        private readonly IInstallmentRecordRepository _installmentRecordRepository;

        public InstallmentRecordRepositoryTests()
        {
            _installmentRecordRepository = GetRequiredService<IInstallmentRecordRepository>();
        }

        /*
        [Fact]
        public async Task Test1()
        {
            await WithUnitOfWorkAsync(async () =>
            {
                // Arrange

                // Act

                //Assert
            });
        }
        */
    }
}
