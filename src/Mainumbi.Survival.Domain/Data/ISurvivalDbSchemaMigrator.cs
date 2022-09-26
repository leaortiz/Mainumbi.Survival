using System.Threading.Tasks;

namespace Mainumbi.Survival.Data;

public interface ISurvivalDbSchemaMigrator
{
    Task MigrateAsync();
}
