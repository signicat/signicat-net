using System;
using System.Collections.Specialized;

namespace Signicat.Infrastructure
{
    internal static class AuthManager
    {
        public static OAuthToken Authorize()
        {
            SignicatConfiguration.OAuthToken =
                Authorize(SignicatConfiguration.ClientId, SignicatConfiguration.ClientSecret);
            return SignicatConfiguration.OAuthToken;
        }

        public static OAuthToken Authorize(string clientId, string clientSecret)
        {
            if (clientId == null)
            {
                throw new InvalidOperationException("Client credentials not set.");
            }

            var formData = new NameValueCollection
            {
                {"grant_type", "client_credentials"},
                {"scope", string.Join(" ", "signicat-api")},
                {"client_id", clientId},
                {"client_secret", clientSecret}
            };

            var token = Mapper.MapFromJson<OAuthToken>(HttpRequestor.PostFormData(Urls.OAuthToken, formData));
            token.Expiry = DateTime.UtcNow.AddSeconds(token.ExpiresIn);
            return token;
        }
    }
}