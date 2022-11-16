using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;

namespace Signicat.Infrastructure
{
    internal static class APIHelper
    {
        public static string DateTimeFormat = "yyyy'-'MM'-'dd'T'HH':'mm':'ss.FFFFFFFK";
        
        public static string AppendQueryParams(string url, Dictionary<string, object> queryParams)
        {
            var q = string.Join("&", queryParams
                .Where(kvp => kvp.Value != null)
                .Select(kvp =>
                {
                    string val;
                    switch (kvp.Value)
                    {
                        case DateTime time:
                            val = time.ToString(DateTimeFormat);
                            break;
                        case DateTimeOffset offset:
                            val = offset.ToString(DateTimeFormat);
                            break;
                        case Enum @enum:
                            val = @enum.ToEnumMemberString();
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
        
        public static string ToEnumMemberString(this Enum enumValue)
        {
            var type = enumValue.GetType();
            var info = type.GetField(enumValue.ToString());
            var da = (EnumMemberAttribute[])(info.GetCustomAttributes(typeof(EnumMemberAttribute), false));
            return da.Length > 0 ? da[0].Value : string.Empty;
        }
    }
}