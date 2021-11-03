using System;
using Volo.Abp;
using Volo.Abp.MongoDB;

namespace EasyAbp.PaymentService.Installment.MongoDB
{
    public static class InstallmentMongoDbContextExtensions
    {
        public static void ConfigureInstallment(
            this IMongoModelBuilder builder,
            Action<AbpMongoModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new InstallmentMongoModelBuilderConfigurationOptions(
                InstallmentDbProperties.DbTablePrefix
            );

            optionsAction?.Invoke(options);
        }
    }
}