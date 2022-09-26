using Volo.Abp.Modularity;

namespace Mainumbi.Pool;

[DependsOn(
    typeof(PoolApplicationModule),
    typeof(PoolDomainTestModule)
    )]
public class PoolApplicationTestModule : AbpModule
{

}
