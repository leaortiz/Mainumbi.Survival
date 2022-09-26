using Volo.Abp.Modularity;

namespace Mainumbi.Wallet;

[DependsOn(
    typeof(WalletApplicationModule),
    typeof(WalletDomainTestModule)
    )]
public class WalletApplicationTestModule : AbpModule
{

}
