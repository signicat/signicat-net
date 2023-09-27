using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using NUnit.Framework;
using Signicat.Authentication;
using Signicat.Constants;
using Signicat.Infrastructure;

namespace Signicat.SDK.Tests;

public class AuthenticationServiceTest : BaseTest
{
    private AuthenticationService _authenticationService;
    private AuthenticationCreateOptions _options;

    [SetUp]
    public void Setup()
    {
        _authenticationService = new AuthenticationService();
        _options = new AuthenticationCreateOptions
        {
            Flow = AuthenticationFlow.Redirect,
            Language = Languages.English,
            AllowedProviders = new List<string>
            {
                AllowedProviderTypes.NorwegianBankId,
                AllowedProviderTypes.SwedishBankID
            },
            ExternalReference = Guid.NewGuid().ToString("n"),
            CallbackUrls = new CallbackUrls
            {
                Abort = "https://mytest.com#abort",
                Success = "https://mytest.com#success",
                Error = "https://mytest.com#error"
            },
            RequestedAttributes = new List<string>
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
        Assert.AreEqual(createSession.Id, session.Id);
        Assert.AreEqual("a-spge-JoXJ5et0okvIKE10LN70", session.AccountId);
        Assert.IsNotEmpty(session.AuthenticationUrl);
    }

    [Test]
    public async Task GetSessionAsync()
    {
        var createSession = await _authenticationService.CreateSessionAsync(_options);
        var session = await _authenticationService.GetSessionAsync(createSession.Id);

        Assert.IsNotNull(session);
        Assert.AreEqual(createSession.Id, session.Id);
        Assert.AreEqual("a-spge-JoXJ5et0okvIKE10LN70", session.AccountId);
        Assert.IsNotEmpty(session.AuthenticationUrl);
    }


    [Test]
    public void CreateSession()
    {
        var session = _authenticationService.CreateSession(_options);

        Assert.IsNotNull(session);
        Assert.AreEqual("a-spge-JoXJ5et0okvIKE10LN70", session.AccountId);
        Assert.IsNotEmpty(session.AuthenticationUrl);
    }

    [Test]
    public async Task CreateSessionAsync()
    {
        var session = await _authenticationService.CreateSessionAsync(_options);

        Assert.IsNotNull(session);
        Assert.AreEqual("a-spge-JoXJ5et0okvIKE10LN70", session.AccountId);
        Assert.IsNotEmpty(session.AuthenticationUrl);
    }
    
    [Test]
    public async Task TestDeserializeSubject()
    {
        var subject =
            "{\"dateOfBirth\":\"1992-01-28\",\"firstName\":\"Donald\",\"id\":\"12345\",\"idpId\":\"54321\"," +
            "\"lastName\":\"Duck\",\"nbidAdditionalCertInfo\":\"{\\\"certValidFrom\\\":1646378708000,\\\"serialNumber\\\":\\\"1234567\\\"" +
            ",\\\"keyAlgorithm\\\":\\\"RSA\\\",\\\"keySize\\\":\\\"2048\\\",\\\"policyOid\\\":\\\"2.16.578.1.16.1.12.1.1\\\",\\\"monetaryLimitAmount\\\"" +
            ":\\\"100000\\\",\\\"certQualified\\\":true,\\\"monetaryLimitCurrency\\\":\\\"NOK\\\",\\\"certValidTo\\\":1709537108000,\\\"versionNumber\\\":" +
            "\\\"3\\\",\\\"subjectName\\\":\\\"CN=Duck\\\\\\\\,Donald,O=TestBank1AS,C=NO,SERIALNUMBER=9562-2000-4-478603\\\"}\",\"nbidAlternativeSubject\":" +
            "\"9562-2000-4-478603\",\"nbidAuthTime\":\"1695727322\",\"nbidIdp\":\"BID\"}";
        var deserialized = Mapper.MapFromJson<Subject>(subject);
        
        Assert.AreEqual(deserialized.Id, "12345");
        Assert.AreEqual(deserialized.LastName, "Duck");
        Assert.NotNull(deserialized.IdpAttributes);
        Assert.IsTrue(deserialized.IdpAttributes.Any());
        Assert.AreEqual(deserialized.IdpAttributes["nbidIdp"].GetString(), "BID");
        Assert.AreEqual(deserialized.IdpAttributes["nbidAuthTime"].GetString(), "1695727322");
        var certInfo = Mapper.MapFromJson<NbidCertInfo>(deserialized.IdpAttributes["nbidAdditionalCertInfo"].GetString());
        Assert.AreEqual(certInfo.KeyAlgorithm, "RSA");
        Assert.IsFalse(deserialized.IdpAttributes.ContainsKey("dateOfBirth"));
    }
    
    private class NbidCertInfo
    {
        public string KeyAlgorithm { get; set; }
    }
}