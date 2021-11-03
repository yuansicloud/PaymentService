using EasyAbp.PaymentService.Installment.InstallmentRecords;
using System;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace EasyAbp.PaymentService.Installment.EntityFrameworkCore
{
    public static class InstallmentDbContextModelCreatingExtensions
    {
        public static void ConfigureInstallment(
            this ModelBuilder builder,
            Action<InstallmentModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new InstallmentModelBuilderConfigurationOptions(
                InstallmentDbProperties.DbTablePrefix,
                InstallmentDbProperties.DbSchema
            );

            optionsAction?.Invoke(options);

            /* Configure all entities here. Example:

            builder.Entity<Question>(b =>
            {
                //Configure table & schema name
                b.ToTable(options.TablePrefix + "Questions", options.Schema);
            
                b.ConfigureByConvention();
            
                //Properties
                b.Property(q => q.Title).IsRequired().HasMaxLength(QuestionConsts.MaxTitleLength);
                
                //Relations
                b.HasMany(question => question.Tags).WithOne().HasForeignKey(qt => qt.QuestionId);

                //Indexes
                b.HasIndex(q => q.CreationTime);
            });
            */


            builder.Entity<InstallmentRecord>(b =>
            {
                b.ToTable(options.TablePrefix + "InstallmentRecords", options.Schema);
                b.ConfigureByConvention(); 
                

                /* Configure more properties here */
            });
        }
    }
}
