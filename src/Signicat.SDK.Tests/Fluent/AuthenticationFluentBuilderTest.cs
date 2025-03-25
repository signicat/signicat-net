using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using NUnit.Framework;
using Signicat.Authentication;
using Signicat.Constants;

namespace Signicat.SDK.Tests.Fluent
{
    public class AuthenticationFluentBuilderTest
    {
        [Test]
        public void TestAllowedProvidersIsSet()
        {
            var options = AuthenticationCreateOptionsBuilder.Create()
                .WithAllowedProviders(AllowedProviderTypes.NorwegianBankId, AllowedProviderTypes.SwedishBankID)
                .BuildWithOutValidation();

            Assert.That(options, Is.Not.Null);
            Assert.That(2, Is.EqualTo(options.AllowedProviders.Count));
            Assert.That(options.AllowedProviders.Contains("nbid"), Is.True);
            Assert.That(options.AllowedProviders.Contains("sbid"), Is.True);
        }

        [Test]
        public void TestLanguageIsSet()
        {
            var options = AuthenticationCreateOptionsBuilder.Create()
                .WithLanguage("no")
                .BuildWithOutValidation();

            Assert.That(options, Is.Not.Null);
            Assert.That("no", Is.EqualTo(options.Language));
        }

        [Test]
        public void TestFlowIsSet()
        {
            var options = AuthenticationCreateOptionsBuilder.Create()
                .WithFlow(AuthenticationFlow.Headless)
                .WithPrefilledInput(nin: "1")
                .Build();

            Assert.That(options, Is.Not.Null);
            Assert.That(AuthenticationFlow.Headless, Is.EqualTo(options.Flow));
        }

        [Test]
        public void TestFlowIsSetToHeadless()
        {
            var options = AuthenticationCreateOptionsBuilder.Create()
                .WithPrefilledInput("test@test.com")
                .WithFlow(AuthenticationFlow.Headless)
                .BuildWithOutValidation();

            Assert.That(options, Is.Not.Null);
            Assert.That(AuthenticationFlow.Headless, Is.EqualTo(options.Flow));
        }


        [Test]
        public void TestRequestedAttributesIsSet()
        {
            var options = AuthenticationCreateOptionsBuilder.Create()
                .WithRequestedAttributes(RequestedAttributes.FirstName, RequestedAttributes.LastName)
                .BuildWithOutValidation();

            Assert.That(options, Is.Not.Null);
            Assert.That(2, Is.EqualTo(options.RequestedAttributes.Count));
            Assert.That(options.RequestedAttributes.Contains(RequestedAttributes.FirstName), Is.True);
            Assert.That(options.RequestedAttributes.Contains(RequestedAttributes.LastName), Is.True);
        }

        [Test]
        public void TestCallbackUrlsIsSet()
        {
            var options = AuthenticationCreateOptionsBuilder.Create()
                .WithCallbackUrls("success", "abort", "error")
                .Build();

            Assert.That(options, Is.Not.Null);
            Assert.That("success", Is.EqualTo(options.CallbackUrls.Success));
            Assert.That("abort", Is.EqualTo(options.CallbackUrls.Abort));
            Assert.That("error", Is.EqualTo(options.CallbackUrls.Error));
        }

        [Test]
        public void TestExternalReferenceIsSet()
        {
            var externalRef = Guid.NewGuid().ToString();
            var options = AuthenticationCreateOptionsBuilder.Create()
                .WithExternalReference(externalRef)
                .BuildWithOutValidation();

            Assert.That(options, Is.Not.Null);
            Assert.That(externalRef, Is.EqualTo(options.ExternalReference));
        }

        [Test]
        public void TestSessionLifeTimeIsSet()
        {
            var options = AuthenticationCreateOptionsBuilder.Create()
                .WithSessionLifetime(95)
                .BuildWithOutValidation();

            Assert.That(options, Is.Not.Null);
            Assert.That(95, Is.EqualTo(options.SessionLifetime));
        }

        [Test]
        public void TestThemeIdIsSet()
        {
            var theme = Guid.NewGuid().ToString();
            var options = AuthenticationCreateOptionsBuilder.Create()
                .WithThemeId(theme)
                .BuildWithOutValidation();

            Assert.That(options, Is.Not.Null);
            Assert.That(theme, Is.EqualTo(options.ThemeId));
        }

        [Test]
        public void TestBuildErrorIfCallbackAreNotSetForRedirect()
        {
            var exception = Assert.Throws<ValidationException>(() => AuthenticationCreateOptionsBuilder.Create()
                .WithFlow(AuthenticationFlow.Redirect)
                .Build());
            Assert.That("Abort url must be set when using flow redirect", Is.EqualTo(exception.Message));
        }

        [Test]
        public void TestBuildErrorIfPrefilledInputNotSetForRedirect()
        {
            var exception = Assert.Throws<ValidationException>(() => AuthenticationCreateOptionsBuilder.Create()
                .WithFlow(AuthenticationFlow.Headless)
                .Build());

            Assert.That("One or more prefilled fields must be set when using flow headless",
                Is.EqualTo(exception.Message));
        }

        [Test]
        [Ignore("Only for show")]
        public async Task PrintToConsoleFluentResult()
        {
            var authenticationService = new AuthenticationService("clientId", "secret");

            var options = AuthenticationCreateOptionsBuilder.Create()
                .WithFlow(AuthenticationFlow.Redirect)
                .WithCallbackUrls("https://myservice.com/success", "https://myservice.com/abort",
                    "https://myservice.com/error")
                .WithLanguage("no")
                .WithAllowedProviders(AllowedProviderTypes.NorwegianBankId, AllowedProviderTypes.iDIN)
                .WithExternalReference(Guid.NewGuid().ToString())
                .WithThemeId("ab1212")
                .WithRequestedAttributes(RequestedAttributes.FirstName, RequestedAttributes.LastName,
                    RequestedAttributes.NationalIdentifierNumber)
                .Build();

            var response = await authenticationService.CreateSessionAsync(options);
        }
    }
}