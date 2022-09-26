using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Mainumbi.Pool.Samples;

public interface ISampleAppService : IApplicationService
{
    Task<SampleDto> Get420Async();

    Task<SampleDto> GetAuthorizedAsync();
}
