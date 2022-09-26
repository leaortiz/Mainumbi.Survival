using Localization.Resources.AbpUi;
using Mainumbi.Wallet.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace Mainumbi.Wallet;

[DependsOn(
    typeof(WalletApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class WalletHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(WalletHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<WalletResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
