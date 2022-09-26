using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Mainumbi.Survival.Data;

/* This is used if database provider does't define
 * ISurvivalDbSchemaMigrator implementation.
 */
public class NullSurvivalDbSchemaMigrator : ISurvivalDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
