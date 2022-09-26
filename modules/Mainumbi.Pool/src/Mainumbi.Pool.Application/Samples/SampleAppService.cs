using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Mainumbi.Pool.Samples;

public class SampleAppService : PoolAppService, ISampleAppService
{
    public Task<SampleDto> Get420Async()
    {
        return Task.FromResult(
            new SampleDto
            {
                Value = 420
            }
        );
    }

    [Authorize]
    public Task<SampleDto> GetAuthorizedAsync()
    {
        return Task.FromResult(
            new SampleDto
            {
                Value = 42
            }
        );
    }
}
