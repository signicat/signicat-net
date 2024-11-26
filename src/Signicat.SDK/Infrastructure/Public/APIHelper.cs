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

        internal static string AppendQueryParam(this string url, string key, object? value = null, string? dateFormat = null)
        {
            if (string.IsNullOrWhiteSpace(url) || value is null)
                return url;
            
            var urlBuilder = new StringBuilder(url)
                .Append(url.Contains("?") ? "&" : "?")
                .Append(key).Append("=");

            var val = value switch
            {
                DateTime => value.ToDateTime(dateFormat ?? DateTimeFormat),
                DateTimeOffset => value.ToDateTimeOffset(dateFormat ?? DateTimeFormat),
                bool  => value.ToString().ToLower(),
                Enum @enum => value.ToEnumMemberString(),
                _ => value.ToString()
            };
            
            urlBuilder.Append(val);
            return urlBuilder.ToString();
        }
        
        internal static string AppendQueryParams(this string url, Dictionary<string, object> queryParams, string? dateFormat = null)
        {
            var q = string.Join("&", queryParams
                .Where(kvp => kvp.Value != null)
                .Select(kvp =>
                {
                    string val;
                    switch (kvp.Value)
                    {
                        case DateTime time:
                            val = time.ToString(dateFormat ?? DateTimeFormat);
                            break;
                        case DateTimeOffset offset:
                            val = offset.ToString(dateFormat ?? DateTimeFormat);
                            break;
                        case Enum @enum:
                            val = kvp.Value.ToEnumMemberString();
                            break;
                        default:
                            val = kvp.Value.ToString();
                            break;
                    }

                    return $"{kvp.Key}={val}";
                }));

            return string.IsNullOrWhiteSpace(q) ? url : $"{url}?{q}";
        }

        public static string ToQueryString(NameValueCollection nvc)
        {
            var array = (from key in nvc.AllKeys
                from value in nvc.GetValues(key)
                select $"{key}={WebUtility.UrlEncode(value)}").ToArray();
            return "?" + string.Join("&", array);
        }

        private static string ToDateTime(this object value, string dateFormat = null)
        {
            DateTime time = (DateTime)value;
            return time.ToString(dateFormat);
        }
        
        private static string ToDateTimeOffset(this object value, string dateFormat = null)
        {
            DateTimeOffset time = (DateTimeOffset)value;
            return time.ToString(dateFormat);
        }

        public static string ToEnumMemberString(this object enumValue)
        {
            var type = enumValue.GetType();
            var info = type.GetField(enumValue.ToString());
            var da = (EnumMemberAttribute[]) info.GetCustomAttributes(typeof(EnumMemberAttribute), false);
            return da.Length > 0 ? da[0].Value : string.Empty;
        }
    }
}