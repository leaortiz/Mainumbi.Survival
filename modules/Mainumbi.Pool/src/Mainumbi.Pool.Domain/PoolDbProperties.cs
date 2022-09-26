namespace Mainumbi.Pool;

public static class PoolDbProperties
{
    public static string DbTablePrefix { get; set; } = "Pool";

    public static string DbSchema { get; set; } = null;

    public const string ConnectionStringName = "Pool";
}
