using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Mainumbi.Pool;

[DependsOn(
    typeof(PoolApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class PoolHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(PoolApplicationContractsModule).Assembly,
            PoolRemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<PoolHttpApiClientModule>();
        });

    }
}
