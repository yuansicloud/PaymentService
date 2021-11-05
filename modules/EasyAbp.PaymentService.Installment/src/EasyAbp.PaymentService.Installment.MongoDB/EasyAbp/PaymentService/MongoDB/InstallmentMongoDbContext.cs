using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace EasyAbp.PaymentService.Installment.MongoDB
{
    [ConnectionStringName(InstallmentDbProperties.ConnectionStringName)]
    public class InstallmentMongoDbContext : AbpMongoDbContext, IInstallmentMongoDbContext
    {
        /* Add mongo collections here. Example:
         * public IMongoCollection<Question> Questions => Collection<Question>();
         */

        protected override void CreateModel(IMongoModelBuilder modelBuilder)
        {
            base.CreateModel(modelBuilder);

            modelBuilder.ConfigureInstallment();
        }
    }
}