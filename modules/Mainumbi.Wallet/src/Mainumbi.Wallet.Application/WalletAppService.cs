using Mainumbi.Wallet.Localization;
using Volo.Abp.Application.Services;

namespace Mainumbi.Wallet;

public abstract class WalletAppService : ApplicationService
{
    protected WalletAppService()
    {
        LocalizationResource = typeof(WalletResource);
        ObjectMapperContext = typeof(WalletApplicationModule);
    }
}
