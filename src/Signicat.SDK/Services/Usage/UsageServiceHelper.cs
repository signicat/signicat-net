using System.Threading.Tasks;
using Signicat.Entities;

namespace Signicat.Services.Usage;

public static class UsageServiceHelper
{
    /// <summary>
    /// Get usage records next page async
    /// </summary>
    /// <param name="usageService">Usage service</param>
    /// <param name="result">result from a full query</param>
    /// <returns></returns>
    public static async Task<UsagePaginationResult> GetNextAsync(this IUsageService usageService, UsagePaginationResult result)
    {
        return string.IsNullOrWhiteSpace(result.Next) ? null : await usageService.GetUsageAsync(result.Next);
    }
    
    /// <summary>
    /// Get usage records next page
    /// </summary>
    /// <param name="usageService">Usage service</param>
    /// <param name="result">result from a full query</param>
    /// <returns></returns>
    public static UsagePaginationResult GetNext(this IUsageService usageService, UsagePaginationResult result)
    {
        return string.IsNullOrWhiteSpace(result.Next) ? null : usageService.GetUsage(result.Next);
    }
    
    /// <summary>
    /// Get usage records previous page async
    /// </summary>
    /// <param name="usageService">Usage service</param>
    /// <param name="result">result from a full query</param>
    /// <returns></returns>
    public static async Task<UsagePaginationResult> GetPreviousAsync(this IUsageService usageService, UsagePaginationResult result)
    {
        return string.IsNullOrWhiteSpace(result.Previous) ? null : await usageService.GetUsageAsync(result.Previous);
    }
    
    /// <summary>
    /// Get usage records previous page
    /// </summary>
    /// <param name="usageService">Usage service</param>
    /// <param name="result">result from a full query</param>
    /// <returns></returns>
    public static UsagePaginationResult GetPrevious(this IUsageService usageService, UsagePaginationResult result)
    {
        return string.IsNullOrWhiteSpace(result.Previous) ? null : usageService.GetUsage(result.Previous);
    }
}