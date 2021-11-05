using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace EasyAbp.PaymentService.Installment.InstallmentRecords
{
    public class InstallmentRecordAppServiceTests : InstallmentApplicationTestBase
    {
        private readonly IInstallmentRecordAppService _installmentRecordAppService;

        public InstallmentRecordAppServiceTests()
        {
            _installmentRecordAppService = GetRequiredService<IInstallmentRecordAppService>();
        }

        /*
        [Fact]
        public async Task Test1()
        {
            // Arrange

            // Act

            // Assert
        }
        */
    }
}
