using System.Threading.Tasks;
using Signicat.Infrastructure;

namespace Signicat.SDK.Tests;

public class TestApiService : SignicatBaseService
{
    public TestApiService()
    {
    }

    public TestApiService(string clientId, string clientSecret)
        : base(clientId, clientSecret)
    {
    }

    public async Task CallEndpointThatThisClientDoNotHavePermssionsToCall()
    {
        await GetAsync<object>($"{Urls.BaseUrl}/auth/open/config/apis");
    }

    public async Task CallEndpointWithoutCredentials()
    {
        Mapper.MapFromJson<object>(await HttpRequestor.GetAsync($"{Urls.BaseUrl}/auth/open/config/apis"));
    }
}