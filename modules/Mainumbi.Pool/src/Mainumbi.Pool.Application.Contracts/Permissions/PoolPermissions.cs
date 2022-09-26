using Volo.Abp.Reflection;

namespace Mainumbi.Pool.Permissions;

public class PoolPermissions
{
    public const string GroupName = "Pool";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(PoolPermissions));
    }
}
