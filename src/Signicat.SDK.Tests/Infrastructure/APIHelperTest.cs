using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using NUnit.Framework;
using Signicat.Infrastructure;

namespace Signicat.SDK.Tests
{
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

            Assert.That(url, Is.Not.Empty);
            Assert.That(
                "https://api.signicat.io?foo=bar&limit=25&fileFormat=standard_packaging&fromDate=2018-01-01T08:00:00Z&toDate=2018-01-01T08:00:00+00:00",
                Is.EqualTo(url));
        }

        [Test]
        public void AppendsQueryParamInUrlWithExistingParams()
        {
            string url =
                "https://api.signicat.com/someapi?foo=bar&limit=25&fileFormat=standard_packaging".AppendQueryParam(
                    "newParam", "TestValue");
            Assert.That(url, Is.Not.Empty);
            Assert.That(url,
                Is.EqualTo(
                    "https://api.signicat.com/someapi?foo=bar&limit=25&fileFormat=standard_packaging&newParam=TestValue"));
        }

        [Test]
        public void AppendsQueryParamInUrlWithNoParams()
        {
            string url = "https://api.signicat.com/someapi".AppendQueryParam("newParam", "TestValue");
            Assert.That(url, Is.Not.Empty);
            Assert.That(url, Is.EqualTo("https://api.signicat.com/someapi?newParam=TestValue"));
        }

        [Test]
        public void AppendsQueryParamInUrlWithBoolParams()
        {
            string url = "https://api.signicat.com/someapi".AppendQueryParam("include", true);
            Assert.That(url, Is.Not.Empty);
            Assert.That(url, Is.EqualTo("https://api.signicat.com/someapi?include=true"));
        }

        [Test]
        public void AppendsQueryParamInUrlWithIntParams()
        {
            string url = "https://api.signicat.com/someapi".AppendQueryParam("include", 16);
            Assert.That(url, Is.Not.Empty);
            Assert.That(url, Is.EqualTo("https://api.signicat.com/someapi?include=16"));
        }

        [Test]
        public void DoesNotAppendsQueryParamInUrlWithIntParams0()
        {
            string url = "https://api.signicat.com/someapi".AppendQueryParam("include", 0);
            Assert.That(url, Is.Not.Empty);
            Assert.That(url, Is.EqualTo("https://api.signicat.com/someapi"));
        }

        [Test]
        public void AppendsQueryParamInUrlWithDateParams()
        {
            string url = "https://api.signicat.com/someapi".AppendQueryParam("from", DateTime.Now, "yyyy-MM-dd");
            Assert.That(url, Is.Not.Empty);
            Console.WriteLine($"https://api.signicat.com/someapi?from={DateTime.Now:yyyy-MM-dd}");
            Assert.That(url, Is.EqualTo($"https://api.signicat.com/someapi?from={DateTime.Now:yyyy-MM-dd}"));
        }

        [Test]
        public void AppendsQueryParamInUrlWithEnumParams()
        {
            string url =
                "https://api.signicat.com/someapi".AppendQueryParam("aggregateByDate", AggregateByDates.Monthly);
            Assert.That(url, Is.Not.Empty);
            Console.WriteLine($"https://api.signicat.com/someapi?from={DateTime.Now:yyyy-MM-dd}");
            Assert.That(url, Is.EqualTo($"https://api.signicat.com/someapi?aggregateByDate=monthly"));
        }

        [Test]
        public void AppendsQueryParamInUrlWithEnumParamsSecond()
        {
            string url =
                "https://api.signicat.com/someapi".AppendQueryParam("aggregateByLevel", AggregateByLevel.Organisation);
            Assert.That(url, Is.Not.Empty);
            Assert.That(url, Is.EqualTo($"https://api.signicat.com/someapi?aggregateByLevel=organization"));
        }

        [Test]
        public void AppendsQueryParamConditionalyShouldNotAddWhenFalse()
        {
            string url =
                "https://api.signicat.com/someapi".AppendQueryParam(false, "aggregateByLevel",
                    AggregateByLevel.Organisation);
            Assert.That(url, Is.Not.Empty);
            Console.WriteLine($"https://api.signicat.com/someapi?from={DateTime.Now:yyyy-MM-dd}");
            Assert.That(url, Is.EqualTo($"https://api.signicat.com/someapi"));
        }

        [Test]
        public void BuildsQueryString()
        {
            var q = ApiHelper.ToQueryString(new NameValueCollection
            {
                {"foo", "bar"},
                {"test_param", "test_value"}
            });

            Assert.That(q, Is.Not.Empty);
            Assert.That("?foo=bar&test_param=test_value", Is.EqualTo(q));
        }
    }
}