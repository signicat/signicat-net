using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using NUnit.Framework;
using Signicat.Authentication;
using Signicat.SDK.Fluent;

namespace Signicat.SDK.Tests.Fluent;

public class AuthenticationFluentBuilderTest
{
    [Test]
    public void TestAllowedProvidersIsSet()
    {
        var options = AuthenticationCreateOptionsBuilder.Create()
            .WithCallbackUrls("test","test","test")
            .WithAllowedProviders(Constants.AllowedProviderTypes.NorwegianBankId, Constants.AllowedProviderTypes.SwedishBankID)
            .Build();
        
        Assert.IsNotNull(options);
        Assert.AreEqual(2, options.AllowedProviders.Count);
        Assert.IsTrue(options.AllowedProviders.Contains("nbid"));
        Assert.IsTrue(options.AllowedProviders.Contains("sbid"));
    }
    
    [Test]
    public void TestLanguageIsSet()
    {
        var options = AuthenticationCreateOptionsBuilder.Create()
            .WithCallbackUrls("test","test","test")
            .WithLanguage("no")
            .Build();
        
        Assert.IsNotNull(options);
        Assert.AreEqual("no", options.Language);
    }
    
    [Test]
    public void TestFlowIsSet()
    {
        var options = AuthenticationCreateOptionsBuilder.Create()
            .WithFlow(AuthenticationFlow.Iframe)
            .Build();
        
        Assert.IsNotNull(options);
        Assert.AreEqual(AuthenticationFlow.Iframe, options.Flow);
    }
    
    [Test]
    public void TestFlowIsSetToHeadless()
    {
        var options = AuthenticationCreateOptionsBuilder.Create()
            .WithPrefilledInput("test@test.com")
            .WithFlow(AuthenticationFlow.Headless)
            .Build();
        
        Assert.IsNotNull(options);
        Assert.AreEqual(AuthenticationFlow.Headless, options.Flow);
    }
    
    
    [Test]
    public void TestRequestedAttributesIsSet()
    {
        var options = AuthenticationCreateOptionsBuilder.Create()
            .WithCallbackUrls("test","test","test")
            .WithRequestedAttributes(Constants.RequestedAttributes.FirstName, Constants.RequestedAttributes.LastName)
            .Build();
        
        Assert.IsNotNull(options);
        Assert.AreEqual(2, options.RequestedAttributes.Count);
        Assert.IsTrue(options.RequestedAttributes.Contains(Constants.RequestedAttributes.FirstName));
        Assert.IsTrue(options.RequestedAttributes.Contains(Constants.RequestedAttributes.LastName));
    }
    
    [Test]
    public void TestCallbackUrlsIsSet()
    {
        var options = AuthenticationCreateOptionsBuilder.Create()
            .WithCallbackUrls("success","abort","error")
            .Build();
        
        Assert.IsNotNull(options);
        Assert.AreEqual("success", options.CallbackUrls.SuccessUrl);
        Assert.AreEqual("abort", options.CallbackUrls.AbortUrl);
        Assert.AreEqual("error", options.CallbackUrls.ErrorUrl);
    }
    
    [Test]
    public void TestExternalReferenceIsSet()
    {
        var externalRef = Guid.NewGuid().ToString();
        var options = AuthenticationCreateOptionsBuilder.Create()
            .WithCallbackUrls("success","abort","error")
            .WithExternalReference(externalRef)
            .Build();
        
        Assert.IsNotNull(options);
        Assert.AreEqual(externalRef, options.ExternalReference);
        
    }
    
    [Test]
    public void TestSessionLifeTimeIsSet()
    {
        var options = AuthenticationCreateOptionsBuilder.Create()
            .WithCallbackUrls("success","abort","error")
            .WithSessionLifetime(95)
            .Build();
        
        Assert.IsNotNull(options);
        Assert.AreEqual(95, options.SessionLifetime);
        
    }
    
    [Test]
    public void TestThemeIdIsSet()
    {
        var theme = Guid.NewGuid().ToString();
        var options = AuthenticationCreateOptionsBuilder.Create()
            .WithCallbackUrls("success","abort","error")
            .WithThemeId(theme)
            .Build();
        
        Assert.IsNotNull(options);
        Assert.AreEqual(theme, options.ThemeId);
        
    }
    
    [Test]
    public void TestBuildErrorIfCallbackAreNotSetForRedirect()
    {
        
        var exception = Assert.Throws<ValidationException>(()=> AuthenticationCreateOptionsBuilder.Create()
            .WithFlow(AuthenticationFlow.Redirect)
            .Build());
        Assert.AreEqual("Abort url must be set when using flow redirect", exception.Message);
    }
    
    [Test]
    public void TestBuildErrorIfPrefilledInputNotSetForRedirect()
    {
        
        var exception = Assert.Throws<ValidationException>(()=> AuthenticationCreateOptionsBuilder.Create()
            .WithFlow(AuthenticationFlow.Headless)
            .Build());
        
        Assert.AreEqual("One or more prefilled fields must be set when using flow headless", exception.Message);

    }

    [Test]
    [Ignore("Only for show")]
    public async Task PrintToConsoleFluentResult()
    {
        var authenticationService = new AuthenticationService("clientId","secret");

        var options = AuthenticationCreateOptionsBuilder.Create()
            .WithFlow(AuthenticationFlow.Redirect)
            .WithCallbackUrls(success: "https://myservice.com/success", abort: "https://myservice.com/abort",
                error: "https://myservice.com/error")
            .WithLanguage("no")
            .WithAllowedProviders(Constants.AllowedProviderTypes.NorwegianBankId, Constants.AllowedProviderTypes.iDIN)
            .WithExternalReference(Guid.NewGuid().ToString())
            .WithThemeId("ab1212")
            .WithRequestedAttributes(Constants.RequestedAttributes.FirstName, Constants.RequestedAttributes.LastName,
                Constants.RequestedAttributes.NationalIdentifierNumber)
            .Build();

        var response = await authenticationService.CreateSessionAsync(options);
    }
}
