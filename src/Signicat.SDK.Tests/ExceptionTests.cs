using System;
using System.Net;
using NUnit.Framework;

namespace Signicat.SDK.Tests;

public class ExceptionTests
{
    private TestApiService _service;

    [SetUp]
    public void Setup()
    {
        if (string.IsNullOrWhiteSpace(Environment.GetEnvironmentVariable("SIGNICAT_CLIENT_ID")) ||
            string.IsNullOrWhiteSpace(Environment.GetEnvironmentVariable("SIGNICAT_CLIENT_SECRET")))
        {
            throw new Exception("Missing credentials will not run");
        }

        _service = new TestApiService(Environment.GetEnvironmentVariable("SIGNICAT_CLIENT_ID"),
            Environment.GetEnvironmentVariable("SIGNICAT_CLIENT_SECRET"));
    }

    [Test]
    public void TestForbiddenExceptionIsThrown()
    {
        var exception =
            Assert.ThrowsAsync<SignicatForbiddenException>(() =>
                _service.CallEndpointThatThisClientDoNotHavePermssionsToCall());

        Assert.IsNotNull(exception);
        Assert.AreEqual(HttpStatusCode.Forbidden, exception.HttpStatusCode);
        Console.WriteLine(exception);
    }

    [Test]
    public void TestUnAuthorizedExceptionIsThrown()
    {
        var exception =
            Assert.ThrowsAsync<SignicatUnauthorizedException>(() =>
                _service.CallEndpointWithoutCredentials());

        Assert.IsNotNull(exception);
        Assert.AreEqual(HttpStatusCode.Unauthorized, exception.HttpStatusCode);
        Console.WriteLine(exception);
    }
}