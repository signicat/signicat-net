using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Signicat.Entities;

namespace Signicat.Services.Usage;

public interface IUsageService
{
    Task<UsagePaginationResult> GetUsageAsync(string next, int limit = 100);
    
    Task<UsagePaginationResult> GetUsageAsync(DateTime fromDate, DateTime? toDate = null, bool includeExternalReference = false, 
        AggregateByDates? aggregateByDate = null, AggregateByLevel? aggregateByLevel = null, bool includeChildOrganisations = false, int limit = 100);
    
    
    UsagePaginationResult GetUsage(string next, int limit = 100);
    
    UsagePaginationResult GetUsage(DateTime fromDate, DateTime? toDate = null, bool includeExternalReference = false, 
        AggregateByDates? aggregateByDate = null, AggregateByLevel? aggregateByLevel = null, bool includeChildOrganisations = false, int limit = 100);
}