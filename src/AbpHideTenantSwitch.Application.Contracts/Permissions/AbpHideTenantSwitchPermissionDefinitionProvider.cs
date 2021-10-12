using AbpHideTenantSwitch.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace AbpHideTenantSwitch.Permissions
{
    public class AbpHideTenantSwitchPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(AbpHideTenantSwitchPermissions.GroupName);
            //Define your own permissions here. Example:
            //myGroup.AddPermission(AbpHideTenantSwitchPermissions.MyPermission1, L("Permission:MyPermission1"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<AbpHideTenantSwitchResource>(name);
        }
    }
}
