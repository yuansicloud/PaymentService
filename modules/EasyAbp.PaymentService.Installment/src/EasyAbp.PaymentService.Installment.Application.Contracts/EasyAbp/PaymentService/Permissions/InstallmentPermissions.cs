using Volo.Abp.Reflection;

namespace EasyAbp.PaymentService.Installment.Permissions
{
    public class InstallmentPermissions
    {
        public const string GroupName = "Installment";

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(InstallmentPermissions));
        }

        public class InstallmentRecord
        {
            public const string Default = GroupName + ".InstallmentRecord";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }
    }
}
