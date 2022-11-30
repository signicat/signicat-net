using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Web;

namespace Signicat
{
    public static class JwtHelper
    {
        internal static string? ParseOutAccountIdFromJwt(this string jwt)
        {
            if (string.IsNullOrWhiteSpace(jwt))
                return null;

            var claimsPartOfJwtBase64Encoded = jwt.Split('.')[1];
            if (string.IsNullOrWhiteSpace(claimsPartOfJwtBase64Encoded))
            {
                return null;
            }

            claimsPartOfJwtBase64Encoded = claimsPartOfJwtBase64Encoded.Replace('-', '+').Replace('_', '/');
            switch (claimsPartOfJwtBase64Encoded.Length % 4)
            {
                case 2: claimsPartOfJwtBase64Encoded += "=="; break;
                case 3: claimsPartOfJwtBase64Encoded += "="; break;
            }  
            var claimsAsJson = Encoding.ASCII.GetString(Convert.FromBase64String(claimsPartOfJwtBase64Encoded));

            Dictionary<string, object> claims = JsonSerializer.Deserialize<Dictionary<string, object>>(claimsAsJson);

            if (claims is not null && claims.ContainsKey("account_id") && !string.IsNullOrWhiteSpace(claims["account_id"].ToString()))
            {
                return claims["account_id"].ToString();
            }

            return null;
        }
        
        internal static Uri AddParameter(this Uri url, string paramName, string paramValue)
        {
            var uriBuilder = new UriBuilder(url);
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            query[paramName] = paramValue;
            uriBuilder.Query = query.ToString();

            return uriBuilder.Uri;
        }
    }
}