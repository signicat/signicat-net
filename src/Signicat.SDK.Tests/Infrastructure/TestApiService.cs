using System;
using System.Threading.Tasks;
using Signicat.Infrastructure;

namespace Signicat.SDK.Tests;

public class TestApiService : SignicatBaseService
{
    private readonly string _urlToCall;
    public TestApiService()
    {
        _urlToCall = $"{Urls.BaseUrl}/mobileid/core/users/{Guid.NewGuid().ToString().ToLowerInvariant()}";
    }

    public TestApiService(string clientId, string clientSecret)
        : base(clientId, clientSecret)
    {
        _urlToCall = $"{Urls.BaseUrl}/mobileid/core/users/{Guid.NewGuid().ToString().ToLowerInvariant()}";
    }

    public async Task CallEndpointThatThisClientDoNotHavePermssionsToCall()
    {
        await GetAsync<object>(_urlToCall);
    }

    public async Task CallEndpointWithoutCredentials()
    {
        Mapper.MapFromJson<object>(await HttpRequestor.GetAsync(_urlToCall));
    }
}