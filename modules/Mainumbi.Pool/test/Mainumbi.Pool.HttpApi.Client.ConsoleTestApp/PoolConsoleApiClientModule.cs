using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace Mainumbi.Pool;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(PoolHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
    )]
public class PoolConsoleApiClientModule : AbpModule
{

}
