using Mainumbi.Survival.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Mainumbi.Survival.Permissions;

public class SurvivalPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(SurvivalPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(SurvivalPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<SurvivalResource>(name);
    }
}
