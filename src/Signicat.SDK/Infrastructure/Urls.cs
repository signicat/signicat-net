namespace Signicat.Infrastructure
{
    internal static class Urls
    {
        internal static string DefaultBaseUrl => "https://api.signicat.com";
        
        internal static string DefaultOAuthBaseUrl => $"{DefaultBaseUrl}/auth/open";

        internal static string BaseUrl => SignicatConfiguration.BaseUrl;

        internal static string OAuthToken => $"{SignicatConfiguration.OAuthBaseUrl}/connect/token";

        internal static string Authentication => $"{BaseUrl}/auth/rest";
        
        internal static string Information => $"{BaseUrl}/info/lookup";
        public static string Dem  => $"{BaseUrl}/dem";
        
        
    }
}