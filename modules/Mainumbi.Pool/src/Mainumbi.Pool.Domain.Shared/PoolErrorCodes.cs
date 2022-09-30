namespace Mainumbi.Pool;

public static class PoolErrorCodes
{
    public static string PoolShouldBeOpen = $"Pool:00001";
    public static string PoolShouldBeInProgress = $"Pool:00002";
    public static string PoolNotEnoughEnrollments = $"Pool:00003";
    public static string NewStateCannotBeOpen = $"Pool:00004";
}
