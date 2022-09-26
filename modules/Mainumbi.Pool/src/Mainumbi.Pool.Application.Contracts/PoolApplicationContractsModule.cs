using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace Mainumbi.Pool;

[DependsOn(
    typeof(PoolDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class PoolApplicationContractsModule : AbpModule
{

}
