using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;

namespace Mainumbi.Pool.Samples;

[Area(PoolRemoteServiceConsts.ModuleName)]
[RemoteService(Name = PoolRemoteServiceConsts.RemoteServiceName)]
[Route("api/Pool/sample")]
public class SampleController : PoolController, ISampleAppService
{
    private readonly ISampleAppService _sampleAppService;

    public SampleController(ISampleAppService sampleAppService)
    {
        _sampleAppService = sampleAppService;
    }

    [HttpGet]
    public async Task<SampleDto> Get420Async()
    {
        return await _sampleAppService.Get420Async();
    }

    [HttpGet]
    [Route("authorized")]
    [Authorize]
    public async Task<SampleDto> GetAuthorizedAsync()
    {
        return await _sampleAppService.Get420Async();
    }
}
