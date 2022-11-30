 using System;
 using System.Collections.Generic;
 using System.Net.Http;
 using System.Text.Json;
 using System.Text.Json.Serialization;
 using System.Threading.Tasks;
 using AutoFixture;
 using NUnit.Framework;
 using Signicat.Authentication;
 using Signicat.Constants;

 namespace Signicat.SDK.Tests
 {
     public class AuthenticationServiceTest : BaseTest
     {
         private AuthenticationService _authenticationService;
         private AuthenticationCreateOptions _options;

         [SetUp]
         public void Setup()
         {
             _authenticationService = new AuthenticationService();
             _options = new AuthenticationCreateOptions()
             {
                 Flow = AuthenticationFlow.Redirect,
                 Language = Languages.English,
                 AllowedProviders = new List<string>()
                 {
                     AllowedProviderTypes.NorwegianBankId,
                     AllowedProviderTypes.SwedishBankID
                 },
                 ExternalReference = Guid.NewGuid().ToString("n"),
                 CallbackUrls = new CallbackUrls()
                 {
                     Abort = "https://mytest.com#abort",
                     Success = "https://mytest.com#success",
                     Error = "https://mytest.com#error",
                 },
                 RequestedAttributes = new List<string>()
                 {
                     RequestedAttributes.FirstName,
                     RequestedAttributes.LastName,
                     RequestedAttributes.NationalIdentifierNumber
                 },
                 SessionLifetime = 60
             };
         }

         [Test]
         public void GetSession()
         {
             var createSession = _authenticationService.CreateSession(_options);

             var session = _authenticationService.GetSession(createSession.Id);
             
             Assert.IsNotNull(session);
             Assert.AreEqual(createSession.Id,session.Id);
             Assert.AreEqual("a-spge-JoXJ5et0okvIKE10LN70",session.AccountId);
             Assert.IsNotEmpty(session.AuthenticationUrl);
         }
         
         [Test]
         public async Task GetSessionAsync()
         {
             var createSession =await  _authenticationService.CreateSessionAsync(_options);
             var session = await _authenticationService.GetSessionAsync(createSession.Id);
             
             Assert.IsNotNull(session);
             Assert.AreEqual(createSession.Id,session.Id);
             Assert.AreEqual("a-spge-JoXJ5et0okvIKE10LN70",session.AccountId);
             Assert.IsNotEmpty(session.AuthenticationUrl);
         }
         
         
         
         [Test]
         public void CreateSession()
         {
             
             var session = _authenticationService.CreateSession(_options);
             
             Assert.IsNotNull(session);
             Assert.AreEqual("a-spge-JoXJ5et0okvIKE10LN70",session.AccountId);
             Assert.IsNotEmpty(session.AuthenticationUrl);
         }
         
         [Test]
         public async Task CreateSessionAsync()
         {
             var session = await _authenticationService.CreateSessionAsync(_options);
             
             Assert.IsNotNull(session);
             Assert.AreEqual("a-spge-JoXJ5et0okvIKE10LN70",session.AccountId);
             Assert.IsNotEmpty(session.AuthenticationUrl);
             
         }
         
     }
 }