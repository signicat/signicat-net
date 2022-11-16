using System;
using System.Linq;
using System.Net.Http;
using NUnit.Framework;
using Signicat.Infrastructure;

namespace Signicat.SDK.Tests
{
    [TestFixture]
    public class HttpRequestorTest : BaseTest
    {
        [Test]
        public void BuildsRequestMessage()
        {
            var url = $"{Urls.Authentication}/{Guid.NewGuid()}";
            var token = "access-token";
            
            var request = HttpRequestor.GetRequestMessage(url, HttpMethod.Get, token);
            
            Assert.IsNotNull(request);
            
            Assert.AreEqual(new Uri(url), request.RequestUri);

            Assert.AreEqual($"Bearer {token}", request.Headers.GetValues("Authorization").FirstOrDefault());

            Assert.AreEqual($"dotnet {SignicatConfiguration.SdkVersion}",
                request.Headers.GetValues("Signicat-SDK").FirstOrDefault());
            
            Assert.AreEqual(HttpMethod.Get, request.Method);
        }
    }
}