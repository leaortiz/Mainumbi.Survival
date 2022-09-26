using Mainumbi.Survival.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Mainumbi.Survival.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class SurvivalController : AbpControllerBase
{
    protected SurvivalController()
    {
        LocalizationResource = typeof(SurvivalResource);
    }
}
