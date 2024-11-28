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
        internal static string Dem => $"{BaseUrl}/dem";

        internal static string ExpressSign = $"{BaseUrl}/express/sign";
        
        internal static string EnterpriseSign => $"{BaseUrl}/enterprise/sign";
        
        internal static string EnterpriseSignOrders => $"{EnterpriseSign}/orders";
        
        internal static string AccountManagement => $"{BaseUrl}/account-management";
        
        internal static string AccountManagementInvoices => $"{AccountManagement}/invoices";
        
        internal static string Usage => $"{BaseUrl}/usage";
        
        internal static string UsageTransactions => $"{Usage}/transactions";
        
    }
}