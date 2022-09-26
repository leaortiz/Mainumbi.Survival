using Volo.Abp.Modularity;

namespace Mainumbi.Survival;

[DependsOn(
    typeof(SurvivalApplicationModule),
    typeof(SurvivalDomainTestModule)
    )]
public class SurvivalApplicationTestModule : AbpModule
{

}
