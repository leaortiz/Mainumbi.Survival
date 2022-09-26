using Mainumbi.Survival.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Mainumbi.Survival;

[DependsOn(
    typeof(SurvivalEntityFrameworkCoreTestModule)
    )]
public class SurvivalDomainTestModule : AbpModule
{

}
