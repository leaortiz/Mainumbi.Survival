using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace Mainumbi.Wallet;

[DependsOn(
    typeof(WalletDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class WalletApplicationContractsModule : AbpModule
{

}
