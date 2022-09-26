using Mainumbi.Wallet.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Mainumbi.Wallet;

public abstract class WalletController : AbpControllerBase
{
    protected WalletController()
    {
        LocalizationResource = typeof(WalletResource);
    }
}
