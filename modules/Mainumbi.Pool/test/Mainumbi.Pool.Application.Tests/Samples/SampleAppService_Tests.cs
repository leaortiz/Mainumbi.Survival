using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace Mainumbi.Pool.Samples;

public class SampleAppService_Tests : PoolApplicationTestBase
{
    private readonly ISampleAppService _sampleAppService;

    public SampleAppService_Tests()
    {
        _sampleAppService = GetRequiredService<ISampleAppService>();
    }

    [Fact]
    public async Task GetAsync()
    {
        var result = await _sampleAppService.Get420Async();
        result.Value.ShouldBe(420);
    }

    [Fact]
    public async Task GetAuthorizedAsync()
    {
        var result = await _sampleAppService.GetAuthorizedAsync();
        result.Value.ShouldBe(42);
    }
}
