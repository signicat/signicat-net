using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using AutoFixture;
using NUnit.Framework;
using Signicat.Authentication;

namespace Signicat.SDK.Tests
{
    public class AuthenticationServiceTest : BaseTest
    {
        private AuthenticationService _authenticationService;

        [SetUp]
        public void Setup()
        {
            _authenticationService = new AuthenticationService();
        }

        [Test]
        public void GetSession()
        {
            var session = _authenticationService.GetSession("1");
            
            Assert.IsNotNull(session);
            AssertRequest(HttpMethod.Get, "/auth/rest/sessions/1");
        }
        
        [Test]
        public async Task GetSessionAsync()
        {
            var session = await _authenticationService.GetSessionAsync("1");
            
            Assert.IsNotNull(session);
            AssertRequest(HttpMethod.Get, "/auth/rest/sessions/1");
        }
        
        
        
        [Test]
        public void CreateSession()
        {
            var options = Fixture.Create<AuthenticationCreateOptions>();
            var session = _authenticationService.CreateSession(options);
            
            Assert.IsNotNull(session);
            AssertRequest(HttpMethod.Post, "/auth/rest/sessions");
        }
        
        [Test]
        public async Task CreateSessionAsync()
        {
            var options = Fixture.Create<AuthenticationCreateOptions>();
            var session = await _authenticationService.CreateSessionAsync(options);
            
            Assert.IsNotNull(session);
            AssertRequest(HttpMethod.Post, "/auth/rest/sessions");
        }
        
        


        
    }
}