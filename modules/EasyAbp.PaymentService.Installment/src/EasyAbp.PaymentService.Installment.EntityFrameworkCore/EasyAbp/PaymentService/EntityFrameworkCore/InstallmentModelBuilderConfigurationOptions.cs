using JetBrains.Annotations;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace EasyAbp.PaymentService.Installment.EntityFrameworkCore
{
    public class InstallmentModelBuilderConfigurationOptions : AbpModelBuilderConfigurationOptions
    {
        public InstallmentModelBuilderConfigurationOptions(
            [NotNull] string tablePrefix = "",
            [CanBeNull] string schema = null)
            : base(
                tablePrefix,
                schema)
        {

        }
    }
}