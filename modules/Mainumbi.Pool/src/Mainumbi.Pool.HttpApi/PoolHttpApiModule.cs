using Localization.Resources.AbpUi;
using Mainumbi.Pool.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace Mainumbi.Pool;

[DependsOn(
    typeof(PoolApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class PoolHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(PoolHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<PoolResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
