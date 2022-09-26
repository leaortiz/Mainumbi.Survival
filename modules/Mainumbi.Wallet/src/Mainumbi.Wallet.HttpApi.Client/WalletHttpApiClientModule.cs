using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Mainumbi.Wallet;

[DependsOn(
    typeof(WalletApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class WalletHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(WalletApplicationContractsModule).Assembly,
            WalletRemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<WalletHttpApiClientModule>();
        });

    }
}
