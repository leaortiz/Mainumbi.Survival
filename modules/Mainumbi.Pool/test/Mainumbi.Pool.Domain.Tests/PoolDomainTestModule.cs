using Mainumbi.Pool.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Mainumbi.Pool;

/* Domain tests are configured to use the EF Core provider.
 * You can switch to MongoDB, however your domain tests should be
 * database independent anyway.
 */
[DependsOn(
    typeof(PoolEntityFrameworkCoreTestModule)
    )]
public class PoolDomainTestModule : AbpModule
{

}
