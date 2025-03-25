#nullable enable
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Text;

namespace Signicat.Infrastructure
{
    internal static class ApiHelper
    {
        private static readonly string DateTimeFormat = "yyyy'-'MM'-'dd'T'HH':'mm':'ss.FFFFFFFK";

        internal static string AppendQueryParam(this string url, bool conditionalAdd, string key, object? value = null,
            string? dateFormat = null)
        {
            if (string.IsNullOrWhiteSpace(url) || value is null || !conditionalAdd)
                return url;

            var urlBuilder = new StringBuilder(url)
                .Append(url.Contains("?") ? "&" : "?")
                .Append(key).Append("=");

            var val = value switch
            {
                DateTime => value.ToDateTime(dateFormat ?? DateTimeFormat),
                DateTimeOffset => value.ToDateTimeOffset(dateFormat ?? DateTimeFormat),
                int => Int32.Parse(value.ToString()) > 0 ? value.ToString() : null,
                bool => (value as bool?).GetValueOrDefault() ? "true" : null,
                Enum @enum => value.ToEnumMemberString(),
                _ => value.ToString()
            };
            if (val == null || string.IsNullOrWhiteSpace(val))
                return url;

            urlBuilder.Append(val);
            return urlBuilder.ToString();
        }

        internal static string AppendQueryParam(this string url, string key, object? value = null,
            string? dateFormat = null)
        {
            return url.AppendQueryParam(true, key, value, dateFormat);
        }

        internal static string AppendQueryParams(this string url, Dictionary<string, object> queryParams,
            string? dateFormat = null)
        {
            var q = string.Join("&", queryParams
                .Where(kvp => kvp.Value != null)
                .Select(kvp =>
                {
                    var val = kvp.Value switch
                    {
                        DateTime time => time.ToString(dateFormat ?? DateTimeFormat),
                        DateTimeOffset offset => offset.ToString(dateFormat ?? DateTimeFormat),
                        Enum @enum => kvp.Value.ToEnumMemberString(),
                        int => Int32.Parse(kvp.Value.ToString()) > 0 ? kvp.Value.ToString() : null,
                        bool => (kvp.Value as bool?).GetValueOrDefault() ? "true" : null,
                        _ => kvp.Value.ToString()
                    };
                    if (val != null && !string.IsNullOrWhiteSpace(val))
                    {
                        return $"{kvp.Key}={val}";
                    }

                    return String.Empty;
                }));

            return string.IsNullOrWhiteSpace(q) ? url : $"{url}?{q}";
        }

        internal static string ToQueryString(NameValueCollection nvc)
        {
            var array = (from key in nvc.AllKeys
                from value in nvc.GetValues(key)
                select $"{key}={WebUtility.UrlEncode(value)}").ToArray();
            return "?" + string.Join("&", array);
        }

        private static string ToDateTime(this object value, string? dateFormat = null)
        {
            DateTime time = (DateTime) value;
            return time.ToString(dateFormat);
        }

        private static string ToDateTimeOffset(this object value, string? dateFormat = null)
        {
            DateTimeOffset time = (DateTimeOffset) value;
            return time.ToString(dateFormat);
        }

        private static string ToEnumMemberString(this object enumValue)
        {
            var type = enumValue.GetType();
            var info = type.GetField(enumValue.ToString());
            var da = (EnumMemberAttribute[]) info.GetCustomAttributes(typeof(EnumMemberAttribute), false);
            return da.Length > 0 ? da[0].Value : string.Empty;
        }
    }
}