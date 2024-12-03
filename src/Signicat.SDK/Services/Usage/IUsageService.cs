using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Signicat.Entities;

namespace Signicat.Services.Usage;

public interface IUsageService
{
    /// <summary>
    /// Get usage records async and paged
    /// </summary>
    /// <param name="next">Next pointer</param>
    /// <param name="limit">How many records to fetch</param>
    /// <returns></returns>
    Task<UsagePaginationResult> GetUsageAsync(string next, int limit = 100);
    
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
    /// <returns></returns>
    Task<UsagePaginationResult> GetUsageAsync(DateTime fromDate, DateTime? toDate = null, bool includeExternalReference = false, 
        AggregateByDates? aggregateByDate = null, AggregateByLevel? aggregateByLevel = null, bool includeChildOrganisations = false, int limit = 100);
    
    /// <summary>
    /// Get usage records and paged
    /// </summary>
    /// <param name="next">Next pointer</param>
    /// <param name="limit">How many records to fetch</param>
    /// <returns></returns>
    UsagePaginationResult GetUsage(string next, int limit = 100);
    
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
    /// <returns></returns>
    UsagePaginationResult GetUsage(DateTime fromDate, DateTime? toDate = null, bool includeExternalReference = false, 
        AggregateByDates? aggregateByDate = null, AggregateByLevel? aggregateByLevel = null, bool includeChildOrganisations = false, int limit = 100);
}