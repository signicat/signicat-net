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
 using Signicat.Infrastructure;
 using JsonConverter = System.Text.Json.Serialization.JsonConverter;

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
             var options = new AuthenticationCreateOptions()
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
                     AbortUrl = "https:mytest.com#abort",
                     SuccessUrl = "https:mytest.com#success",
                     ErrorUrl = "https:mytest.com#error",
                 },
                 RequestedAttributes = new List<string>()
                 {
                     RequestedAttributes.FirstName,
                     RequestedAttributes.LastName,
                     RequestedAttributes.NationalIdentifierNumber
                 },
                 SessionLifetime = 60
             };
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
         
         [Test]
         public async Task Serialize()
         {
             var createAuth = new AuthenticationCreateOptions()
             {
                 Flow = AuthenticationFlow.Redirect,
                 Language = Languages.English,
                 AllowedProviders = new List<string>()
                 {
                     AllowedProviderTypes.NorwegianBankId,
                     AllowedProviderTypes.SwedishBankID
                 },
                 CallbackUrls = new CallbackUrls()
                 {
                     AbortUrl = "https:www.example.com#abort",
                     SuccessUrl = "https:www.example.com#success",
                     ErrorUrl = "https:www.example.com#error",
                 },
                 ExternalReference = Guid.NewGuid().ToString("n"),
                 RequestedAttributes = new List<string>()
                 {
                     RequestedAttributes.NationalIdentifierNumber,
                     RequestedAttributes.FirstName,
                     RequestedAttributes.LastName
                 },
                 ThemeId = "231"
             };

             var settings = new JsonSerializerOptions()
             {
                 WriteIndented = true,

             };
             settings.Converters.Add(new JsonStringEnumConverter());
             var json = System.Text.Json.JsonSerializer.Serialize(createAuth,settings);
             Console.WriteLine(json);

             var authObject = JsonSerializer.Deserialize<AuthenticationCreateOptions>(json, settings);

             var session = new AuthenticationSession();
             
             
             Assert.IsTrue(authObject.AllowedProviders.Contains(AllowedProviderTypes.NorwegianBankId));
             Assert.IsTrue(authObject.AllowedProviders.Contains(AllowedProviderTypes.SwedishBankID));
             Assert.AreEqual(2,authObject.AllowedProviders.Count);
         }
         
         


         
     }
 }