using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using AutoFixture;
using Moq;
using Moq.Protected;

namespace Signicat.SDK.Tests
{
    public class BaseTest
    {
        // Used to create objects with test data.
        protected static readonly Fixture Fixture = new Fixture();
        
        // Used to override the HTTP message handler used by HttpRequestor,
        // which lets us verify that the correct HTTP requests are sent.
        private static Mock<HttpClientHandler> _mockHttpClientHandler;

        // Ensures that the we only run initialization once.
        private static readonly Lazy<object> Initializer = new Lazy<object>(Initialize);
        
        public BaseTest()
        {
            // Triggers the lazy initialization
            var init = Initializer.Value;
        }
        
        private static object Initialize()
        {
            var port = Environment.GetEnvironmentVariable("IDFY_MOCK_SERVER_PORT") ?? "5000";
            var url = $"http://localhost:{port}";

            _mockHttpClientHandler = new Mock<HttpClientHandler>()
            {
                CallBase =  true
            };

            SignicatConfiguration.HttpClient = new HttpClient(_mockHttpClientHandler.Object);
            SignicatConfiguration.BaseUrl = url;
            SignicatConfiguration.OAuthBaseUrl = url + "/oauth";
            SignicatConfiguration.SetClientCredentials("signicat-sdk-test", "secret");
            
            // Make sure that the Idfy Mock Server is running
            using (var client = new HttpClient())
            {
                try
                {
                    var response = client.GetAsync(url).Result;
                }
                catch (Exception)
                {
                    throw new Exception($"Failed to connect to Idfy Mock Server at {url}, make sure it is running.");
                }
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
}