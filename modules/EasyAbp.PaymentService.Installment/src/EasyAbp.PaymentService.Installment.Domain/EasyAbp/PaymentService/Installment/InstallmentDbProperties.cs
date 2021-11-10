namespace EasyAbp.PaymentService.Installment
{
    public static class InstallmentDbProperties
    {
        public static string DbTablePrefix { get; set; } = "EasyAbpPaymentServiceInstallment";

        public static string DbSchema { get; set; } = null;

        public const string ConnectionStringName = "EasyAbpPaymentServiceInstallment";
    }
}
