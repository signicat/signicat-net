using System;
using System.Linq;
using System.Net.Http;
using NUnit.Framework;
using Signicat.Infrastructure;

namespace Signicat.SDK.Tests;

[TestFixture]
public class HttpRequestorTest : BaseTest
{
    [Test]
    public void BuildsRequestMessage()
    {
        var url = $"{Urls.Authentication}/{Guid.NewGuid()}";
        var token =
            "eyJhbGciOiJSUzI1NiIsImtpZCI6InNhbmRib3gtc2lnbmluZy1rZXktYTEyYWRlMDBmMTUzOTk0NWE3OTYwMjQ2ZWM1MjkwNDUiLCJ0eXAiOiJhdCtqd3QifQ.eyJuYmYiOjE2Njk3OTk4NzksImV4cCI6MTY2OTgwMDQ3OSwiaXNzIjoiaHR0cHM6Ly9hcGkuc2lnbmljYXQuY29tL2F1dGgvb3BlbiIsImF1ZCI6Imh0dHBzOi8vYXBpLnNpZ25pY2F0LmNvbSIsImNsaWVudF9pZCI6InNhbmRib3gtaGVhbHRoeS1oYXQtMjM5IiwiYWNjb3VudF9pZCI6ImEtc3BnZS1Kb1hKNWV0MG9rdklLRTEwTE43MCIsImp0aSI6IjlFOEE4NDVBQTlDRUMzMjlEMTE1NDg3Njc0MTA4NzAyIiwiaWF0IjoxNjY5Nzk5ODc5LCJzYW5kYm94Ijp0cnVlLCJzY29wZSI6WyJzaWduaWNhdC1hcGkiXX0.yD-al0ontVdhuEi0O2fONm7LQjBNJtmyMrWoKp8vDlPD1B5SrA8ZBSQDoNiiVIjVU1OrGjkiAkcxkyCzJypX-XFUOh9QsaoGZ4nhjn1g58pxqRID8N1lV-mt9qmfOVKK9IGAPQabGmpWXEXWU5Rx5tvyeXQDOj8UszTNOV-x1zrDDYm4KpjZMfJ0d4rAnbriSqB4p9-1Yd-kPegiWMgMWa7ZoVCm7rCiSnFuGcgld6qO_Ckpqzm79jbLe9S_1ekerDMbdM5nC61XVzXjKJnmw5BPLLypJ8gEZ2027eSUP86GiUUofDyCdJNNsJv1viBKyNEggRigZkW7MHHLGZ7v5w";

        var request = HttpRequestor.GetRequestMessage(url, HttpMethod.Get, token);

        Assert.That(request, Is.Not.Null);

        Assert.That(new Uri(url).AddParameter("signicat-accountId", token.ParseOutAccountIdFromJwt()),
            Is.EqualTo(request.RequestUri));

        Assert.That($"Bearer {token}",Is.EqualTo( request.Headers.GetValues("Authorization").FirstOrDefault()));

        Assert.That($"dotnet {SignicatConfiguration.SdkVersion}",
            Is.EqualTo(request.Headers.GetValues("Signicat-SDK").FirstOrDefault()));

        Assert.That(HttpMethod.Get,Is.EqualTo( request.Method));
    }
}