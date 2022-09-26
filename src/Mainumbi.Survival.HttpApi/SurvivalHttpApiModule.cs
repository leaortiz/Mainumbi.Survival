using Localization.Resources.AbpUi;
using Mainumbi.Survival.Localization;
using Volo.Abp.Account;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement.HttpApi;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;
using Mainumbi.Pool;
using Mainumbi.Wallet;

namespace Mainumbi.Survival;

[DependsOn(
    typeof(SurvivalApplicationContractsModule),
    typeof(AbpAccountHttpApiModule),
    typeof(AbpIdentityHttpApiModule),
    typeof(AbpPermissionManagementHttpApiModule),
    typeof(AbpTenantManagementHttpApiModule),
    typeof(AbpFeatureManagementHttpApiModule),
    typeof(AbpSettingManagementHttpApiModule)
    )]
[DependsOn(typeof(PoolHttpApiModule))]
    [DependsOn(typeof(WalletHttpApiModule))]
    public class SurvivalHttpApiModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        ConfigureLocalization();
    }

    private void ConfigureLocalization()
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<SurvivalResource>()
                .AddBaseTypes(
                    typeof(AbpUiResource)
                );
        });
    }
}
