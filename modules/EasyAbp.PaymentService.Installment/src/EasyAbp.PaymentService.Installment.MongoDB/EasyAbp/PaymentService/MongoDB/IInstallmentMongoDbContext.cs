using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace EasyAbp.PaymentService.Installment.MongoDB
{
    [ConnectionStringName(InstallmentDbProperties.ConnectionStringName)]
    public interface IInstallmentMongoDbContext : IAbpMongoDbContext
    {
        /* Define mongo collections here. Example:
         * IMongoCollection<Question> Questions { get; }
         */
    }
}
