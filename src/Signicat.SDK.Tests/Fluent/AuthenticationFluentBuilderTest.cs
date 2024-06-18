using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using NUnit.Framework;
using Signicat.Authentication;
using Signicat.Constants;

namespace Signicat.SDK.Tests.Fluent;

public class AuthenticationFluentBuilderTest
{
    [Test]
    public void TestAllowedProvidersIsSet()
    {
        var options = AuthenticationCreateOptionsBuilder.Create()
            .WithAllowedProviders(AllowedProviderTypes.NorwegianBankId, AllowedProviderTypes.SwedishBankID)
            .BuildWithOutValidation();

        Assert.IsNotNull(options);
        Assert.AreEqual(2, options.AllowedProviders.Count);
        Assert.IsTrue(options.AllowedProviders.Contains("nbid"));
        Assert.IsTrue(options.AllowedProviders.Contains("sbid"));
    }

    [Test]
    public void TestLanguageIsSet()
    {
        var options = AuthenticationCreateOptionsBuilder.Create()
            .WithLanguage("no")
            .BuildWithOutValidation();

        Assert.IsNotNull(options);
        Assert.AreEqual("no", options.Language);
    }

    [Test]
    public void TestFlowIsSet()
    {
        var options = AuthenticationCreateOptionsBuilder.Create()
            .WithFlow(AuthenticationFlow.Headless)
            .WithPrefilledInput(nin: "1")
            .Build();

        Assert.IsNotNull(options);
        Assert.AreEqual(AuthenticationFlow.Headless, options.Flow);
    }

    [Test]
    public void TestFlowIsSetToHeadless()
    {
        var options = AuthenticationCreateOptionsBuilder.Create()
            .WithPrefilledInput("test@test.com")
            .WithFlow(AuthenticationFlow.Headless)
            .BuildWithOutValidation();

        Assert.IsNotNull(options);
        Assert.AreEqual(AuthenticationFlow.Headless, options.Flow);
    }


    [Test]
    public void TestRequestedAttributesIsSet()
    {
        var options = AuthenticationCreateOptionsBuilder.Create()
            .WithRequestedAttributes(RequestedAttributes.FirstName, RequestedAttributes.LastName)
            .BuildWithOutValidation();

        Assert.IsNotNull(options);
        Assert.AreEqual(2, options.RequestedAttributes.Count);
        Assert.IsTrue(options.RequestedAttributes.Contains(RequestedAttributes.FirstName));
        Assert.IsTrue(options.RequestedAttributes.Contains(RequestedAttributes.LastName));
    }

    [Test]
    public void TestCallbackUrlsIsSet()
    {
        var options = AuthenticationCreateOptionsBuilder.Create()
            .WithCallbackUrls("success", "abort", "error")
            .Build();

        Assert.IsNotNull(options);
        Assert.AreEqual("success", options.CallbackUrls.Success);
        Assert.AreEqual("abort", options.CallbackUrls.Abort);
        Assert.AreEqual("error", options.CallbackUrls.Error);
    }

    [Test]
    public void TestExternalReferenceIsSet()
    {
        var externalRef = Guid.NewGuid().ToString();
        var options = AuthenticationCreateOptionsBuilder.Create()
            .WithExternalReference(externalRef)
            .BuildWithOutValidation();

        Assert.IsNotNull(options);
        Assert.AreEqual(externalRef, options.ExternalReference);
    }

    [Test]
    public void TestSessionLifeTimeIsSet()
    {
        var options = AuthenticationCreateOptionsBuilder.Create()
            .WithSessionLifetime(95)
            .BuildWithOutValidation();

        Assert.IsNotNull(options);
        Assert.AreEqual(95, options.SessionLifetime);
    }

    [Test]
    public void TestThemeIdIsSet()
    {
        var theme = Guid.NewGuid().ToString();
        var options = AuthenticationCreateOptionsBuilder.Create()
            .WithThemeId(theme)
            .BuildWithOutValidation();

        Assert.IsNotNull(options);
        Assert.AreEqual(theme, options.ThemeId);
    }

    [Test]
    public void TestBuildErrorIfCallbackAreNotSetForRedirect()
    {
        var exception = Assert.Throws<ValidationException>(() => AuthenticationCreateOptionsBuilder.Create()
            .WithFlow(AuthenticationFlow.Redirect)
            .Build());
        Assert.AreEqual("Abort url must be set when using flow redirect", exception.Message);
    }

    [Test]
    public void TestBuildErrorIfPrefilledInputNotSetForRedirect()
    {
        var exception = Assert.Throws<ValidationException>(() => AuthenticationCreateOptionsBuilder.Create()
            .WithFlow(AuthenticationFlow.Headless)
            .Build());

        Assert.AreEqual("One or more prefilled fields must be set when using flow headless", exception.Message);
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

        await authenticationService.CreateSessionAsync(options);
    }
}