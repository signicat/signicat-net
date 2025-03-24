using System;
using System.Threading.Tasks;
using Signicat.Entities;

namespace Signicat.Services.Usage;

public interface IUsageService
{
    /// <summary>
    /// Get usage records page async 
    /// </summary>
    /// <param name="nextOrPrevious">Next or previous pointer</param>
    /// <returns></returns>
    Task<UsagePaginationResult> GetUsageAsync(string nextOrPrevious);
    
    /// <summary>
    /// Get usage records async for an Organisation
    /// </summary>
    /// <param name="fromDate">Date to fetch from</param>
    /// <param name="toDate">If not, will use current date</param>
    /// <param name="includeExternalReference">If true it will include and group by external reference, this is API property on various products. This is used for customers to group product usage by for example department or country.</param>
    /// <param name="aggregateByDate">Aggregate by date level (date|month|year)</param>
    /// <param name="aggregateByLevel">Aggregate by Organisation or account level (account|organisation)</param>
    /// <param name="includeChildOrganisations">Include child Organisation, only relevant for partners with nested Organisation structures</param>
    /// <param name="limit">How many records to fetch</param>
    /// <param name="offset">How many records to offset</param>
    /// <returns></returns>
    Task<UsagePaginationResult> GetUsageAsync(DateTime fromDate, DateTime? toDate = null, bool includeExternalReference = false, 
        AggregateByDates? aggregateByDate = AggregateByDates.MONTHLY, AggregateByLevel? aggregateByLevel = AggregateByLevel.ORGANIZATION, bool includeChildOrganisations = false, int limit = 0, int offset = 0);
    
    /// <summary>
    /// Get usage records page async
    /// </summary>
    /// <param name="nextOrPrevious">Next or previous pointer</param>
    /// <returns></returns>
    UsagePaginationResult GetUsage(string nextOrPrevious);
    
    /// <summary>
    /// Get usage records for an Organisation
    /// </summary>
    /// <param name="fromDate">Date to fetch from</param>
    /// <param name="toDate">If not, will use current date</param>
    /// <param name="includeExternalReference">If true it will include and group by external reference, this is API property on various products. This is used for customers to group product usage by for example department or country.</param>
    /// <param name="aggregateByDate">Aggregate by date level (date|month|year)</param>
    /// <param name="aggregateByLevel">Aggregate by Organisation or account level (account|organisation)</param>
    /// <param name="includeChildOrganisations">Include child Organisation, only relevant for partners with nested Organisation structures</param>
    /// <param name="limit">How many records to fetch</param>
    /// <param name="offset">How many records to offset</param>
    /// <returns></returns>
    UsagePaginationResult GetUsage(DateTime fromDate, DateTime? toDate = null, bool includeExternalReference = false, 
        AggregateByDates? aggregateByDate = AggregateByDates.MONTHLY, AggregateByLevel? aggregateByLevel = AggregateByLevel.ORGANIZATION, bool includeChildOrganisations = false, int limit = 0, int offset = 0);
}