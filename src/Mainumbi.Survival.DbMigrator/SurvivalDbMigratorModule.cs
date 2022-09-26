using Mainumbi.Survival.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace Mainumbi.Survival.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(SurvivalEntityFrameworkCoreModule),
    typeof(SurvivalApplicationContractsModule)
    )]
public class SurvivalDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}
