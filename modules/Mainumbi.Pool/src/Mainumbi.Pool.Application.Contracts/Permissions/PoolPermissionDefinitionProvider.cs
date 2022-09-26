using Mainumbi.Pool.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Mainumbi.Pool.Permissions;

public class PoolPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(PoolPermissions.GroupName, L("Permission:Pool"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<PoolResource>(name);
    }
}
