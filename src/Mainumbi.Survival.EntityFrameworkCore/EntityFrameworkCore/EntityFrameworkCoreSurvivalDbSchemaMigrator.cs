using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Mainumbi.Survival.Data;
using Volo.Abp.DependencyInjection;

namespace Mainumbi.Survival.EntityFrameworkCore;

public class EntityFrameworkCoreSurvivalDbSchemaMigrator
    : ISurvivalDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreSurvivalDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the SurvivalDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<SurvivalDbContext>()
            .Database
            .MigrateAsync();
    }
}
