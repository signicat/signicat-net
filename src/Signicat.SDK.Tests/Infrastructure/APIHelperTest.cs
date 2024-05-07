using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using NUnit.Framework;
using Signicat.Infrastructure;

namespace Signicat.SDK.Tests;

[TestFixture]
public class APIHelperTest : BaseTest
{
    [Test]
    public void AppendsQueryParams()
    {
        var q = new Dictionary<string, object>
        {
            {"foo", "bar"},
            {"limit", 25},
            {"fileFormat", "standard_packaging"},
            {"fromDate", new DateTime(2018, 01, 01, 8, 0, 0, DateTimeKind.Utc)},
            {"toDate", new DateTimeOffset(2018, 01, 01, 8, 0, 0, TimeSpan.Zero)},
            {"mock", null}
        };

        var url = ApiHelper.AppendQueryParams("https://api.signicat.io", q);

        Assert.IsNotEmpty(url);
        Assert.AreEqual(
            "https://api.signicat.io?foo=bar&limit=25&fileFormat=standard_packaging&fromDate=2018-01-01T08:00:00Z&toDate=2018-01-01T08:00:00+00:00",
            url);
    }

    [Test]
    public void BuildsQueryString()
    {
        var q = ApiHelper.ToQueryString(new NameValueCollection
        {
            {"foo", "bar"},
            {"test_param", "test_value"}
        });

        Assert.IsNotEmpty(q);
        Assert.AreEqual("?foo=bar&test_param=test_value", q);
    }
}