using EasyAbp.PaymentService.Installment.Samples;
using Xunit;

namespace EasyAbp.PaymentService.Installment.MongoDB.Samples
{
    [Collection(MongoTestCollection.Name)]
    public class SampleRepository_Tests : SampleRepository_Tests<InstallmentMongoDbTestModule>
    {
        /* Don't write custom repository tests here, instead write to
         * the base class.
         * One exception can be some specific tests related to MongoDB.
         */
    }
}
