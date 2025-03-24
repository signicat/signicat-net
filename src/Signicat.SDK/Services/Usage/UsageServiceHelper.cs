using System.Threading.Tasks;
using Signicat.Entities;

namespace Signicat.Services.Usage;

public static class UsageServiceHelper
{
    public static async Task<UsagePaginationResult> GetNextAsync(this IUsageService usageService, UsagePaginationResult result)
    {
        return result.Next is null ? null : await usageService.GetUsageAsync(result.Next, 100);
    }
    
    public static UsagePaginationResult GetNext(this IUsageService usageService, UsagePaginationResult result)
    {
        return result.Next is null ? null : usageService.GetUsage(result.Next, 100);
    }
}