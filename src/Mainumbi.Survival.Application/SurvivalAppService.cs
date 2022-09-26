using System;
using System.Collections.Generic;
using System.Text;
using Mainumbi.Survival.Localization;
using Volo.Abp.Application.Services;


namespace Mainumbi.Survival;

/* Inherit your application services from this class.
 */
public abstract class SurvivalAppService : ApplicationService
{
    protected SurvivalAppService()
    {
        LocalizationResource = typeof(SurvivalResource);
    }
}
