using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace Mainumbi.Wallet;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(WalletHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
    )]
public class WalletConsoleApiClientModule : AbpModule
{

}
