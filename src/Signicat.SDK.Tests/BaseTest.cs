using System;
using System.Net.Http;
using System.Threading;
using AutoFixture;
using Moq;
using Moq.Protected;
using Signicat.Infrastructure;

namespace Signicat.SDK.Tests;

public class BaseTest
{
    // Used to create objects with test data.
    protected static readonly Fixture Fixture = new();

    // Used to override the HTTP message handler used by HttpRequestor,
    // which lets us verify that the correct HTTP requests are sent.
    private static Mock<HttpClientHandler> _mockHttpClientHandler;

    // Ensures that we only run initialization once.
    private static readonly Lazy<object> Initializer = new(Initialize);

    public BaseTest()
    {
        // Triggers the lazy initialization
        var init = Initializer.Value;
    }

    private static object Initialize()
    {
        _mockHttpClientHandler = new Mock<HttpClientHandler>
        {
            CallBase = true
        };

        SignicatConfiguration.HttpClient = new HttpClient(_mockHttpClientHandler.Object);
        SignicatConfiguration.BaseUrl = "https://api.signicat.com";
        SignicatConfiguration.OAuthBaseUrl = SignicatConfiguration.BaseUrl + "/auth/open";

        SignicatConfiguration.SetClientCredentials(Environment.GetEnvironmentVariable("SIGNICAT_CLIENT_ID"),
            Environment.GetEnvironmentVariable("SIGNICAT_CLIENT_SECRET"));

        Console.WriteLine($"ClientId: {Environment.GetEnvironmentVariable("SIGNICAT_CLIENT_ID")}, secret: {Environment.GetEnvironmentVariable("SIGNICAT_CLIENT_SECRET")}");

        var url = $"{SignicatConfiguration.OAuthBaseUrl}/.well-known/openid-configuration";

        // Make sure that we are able to connect to Signicat service
        using (var client = new HttpClient())
        {
            try
            {
                var response = client.GetAsync(url).Result;
            }
            catch (Exception)
            {
                throw new Exception($"Failed to connect to Signicat Server at {url}");
            }
           var token = AuthManager.Authorize(Environment.GetEnvironmentVariable("SIGNICAT_CLIENT_ID"),
                Environment.GetEnvironmentVariable("SIGNICAT_CLIENT_SECRET").Trim());
           
           if(token is null || string.IsNullOrWhiteSpace(token.AccessToken))
               throw new Exception($"Failed to get token from Signicat Server at {url}");
        }

        return null;
    }

    protected void AssertRequest(HttpMethod method, string path)
    {
        _mockHttpClientHandler.Protected().Verify("SendAsync",
            Times.Once(),
            ItExpr.Is<HttpRequestMessage>(m =>
                m.Method == method &&
                $"{m.RequestUri.AbsolutePath}{m.RequestUri.Query}" == path),
            ItExpr.IsAny<CancellationToken>());

        // Resets the recorded invocation before each test
        _mockHttpClientHandler.Invocations.Clear();
    }
}