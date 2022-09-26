using Mainumbi.Pool.Localization;
using Volo.Abp.Application.Services;

namespace Mainumbi.Pool;

public abstract class PoolAppService : ApplicationService
{
    protected PoolAppService()
    {
        LocalizationResource = typeof(PoolResource);
        ObjectMapperContext = typeof(PoolApplicationModule);
    }
}
