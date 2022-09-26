using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Mainumbi.Survival;

[Dependency(ReplaceServices = true)]
public class SurvivalBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Survival";
}
