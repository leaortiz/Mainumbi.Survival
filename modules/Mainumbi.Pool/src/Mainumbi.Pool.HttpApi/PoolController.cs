using Mainumbi.Pool.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Mainumbi.Pool;

public abstract class PoolController : AbpControllerBase
{
    protected PoolController()
    {
        LocalizationResource = typeof(PoolResource);
    }
}
