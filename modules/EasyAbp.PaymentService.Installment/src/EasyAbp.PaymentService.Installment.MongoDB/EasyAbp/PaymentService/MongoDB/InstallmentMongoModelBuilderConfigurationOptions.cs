using JetBrains.Annotations;
using Volo.Abp.MongoDB;

namespace EasyAbp.PaymentService.Installment.MongoDB
{
    public class InstallmentMongoModelBuilderConfigurationOptions : AbpMongoModelBuilderConfigurationOptions
    {
        public InstallmentMongoModelBuilderConfigurationOptions(
            [NotNull] string collectionPrefix = "")
            : base(collectionPrefix)
        {
        }
    }
}