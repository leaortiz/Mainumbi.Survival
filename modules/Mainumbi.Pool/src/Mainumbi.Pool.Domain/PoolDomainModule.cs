using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Mainumbi.Pool;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(PoolDomainSharedModule)
)]
public class PoolDomainModule : AbpModule
{

}
