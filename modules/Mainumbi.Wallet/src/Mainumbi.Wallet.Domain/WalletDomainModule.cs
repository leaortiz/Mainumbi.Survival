using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Mainumbi.Wallet;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(WalletDomainSharedModule)
)]
public class WalletDomainModule : AbpModule
{

}
