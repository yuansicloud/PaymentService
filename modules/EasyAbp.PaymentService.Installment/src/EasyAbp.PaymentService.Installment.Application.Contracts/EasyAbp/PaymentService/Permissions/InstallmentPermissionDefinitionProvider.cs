using EasyAbp.PaymentService.Installment.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace EasyAbp.PaymentService.Installment.Permissions
{
    public class InstallmentPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(InstallmentPermissions.GroupName, L("Permission:Installment"));

            var installmentRecordPermission = myGroup.AddPermission(InstallmentPermissions.InstallmentRecord.Default, L("Permission:InstallmentRecord"));
            installmentRecordPermission.AddChild(InstallmentPermissions.InstallmentRecord.Create, L("Permission:Create"));
            installmentRecordPermission.AddChild(InstallmentPermissions.InstallmentRecord.Update, L("Permission:Update"));
            installmentRecordPermission.AddChild(InstallmentPermissions.InstallmentRecord.Delete, L("Permission:Delete"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<InstallmentResource>(name);
        }
    }
}
