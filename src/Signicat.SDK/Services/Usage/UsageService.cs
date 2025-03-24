using System;
using System.Threading.Tasks;
using Signicat.Entities;
using Signicat.Infrastructure;


namespace Signicat.Services.Usage;

public class UsageService : SignicatBaseService, IUsageService
{
    public UsageService(string organisationId): base(organisationId)
    {
        if (string.IsNullOrWhiteSpace(organisationId) || !organisationId.StartsWith("o-"))
        {
            throw new ArgumentException("Organisation ID must start with 'o-' and is required to use the usage endpoint", nameof(organisationId));
        }
    }
    
    public Task<UsagePaginationResult> GetUsageAsync(string nextOrPrevious)
    {
        if(string.IsNullOrWhiteSpace(nextOrPrevious) || !nextOrPrevious.StartsWith("https://"))
            throw new ArgumentException($"Invalid nextOrPrevious URL: {nextOrPrevious}", nameof(nextOrPrevious));
        return GetAsync<UsagePaginationResult>(nextOrPrevious);
    }

    public Task<UsagePaginationResult> GetUsageAsync(DateTime fromDate,
        DateTime? toDate = null,
        bool includeExternalReference = false, AggregateByDates? aggregateByDate = AggregateByDates.MONTHLY, 
        AggregateByLevel? aggregateByLevel = AggregateByLevel.ORGANIZATION, bool includeChildOrganisations = false, int limit = 0, int offset = 0)
    {
        return GetAsync<UsagePaginationResult>(BuildUrl(fromDate, toDate, includeExternalReference, aggregateByDate,
            aggregateByLevel, includeChildOrganisations, limit, offset));
    }

    public UsagePaginationResult GetUsage(string nextOrPrevious)
    {
        if(string.IsNullOrWhiteSpace(nextOrPrevious) || !nextOrPrevious.StartsWith("https://"))
            throw new ArgumentException($"Invalid nextOrPrevious URL: {nextOrPrevious}", nameof(nextOrPrevious));
        return Get<UsagePaginationResult>(nextOrPrevious);
    }

    public UsagePaginationResult GetUsage(DateTime fromDate,
        DateTime? toDate = null,
        bool includeExternalReference = false, AggregateByDates? aggregateByDate = AggregateByDates.MONTHLY, 
        AggregateByLevel? aggregateByLevel = AggregateByLevel.ORGANIZATION, bool includeChildOrganisations = false, int limit = 0, int offset = 0)
    {
        return Get<UsagePaginationResult>(BuildUrl(fromDate, toDate, includeExternalReference, aggregateByDate,
            aggregateByLevel, includeChildOrganisations, limit, offset));
    }

    internal static string BuildUrl(DateTime fromDate, DateTime? toDate = null,
        bool includeExternalReference = false, AggregateByDates? aggregateByDate = null,
        AggregateByLevel? aggregateByLevel = null, bool includeChildOrganisations = false, int limit = 0, int offset = 0)
    {

        var url= $"{Urls.UsageTransactions}"
            .AppendQueryParam(nameof(fromDate), fromDate, "yyyy-MM-dd")
            .AppendQueryParam(nameof(toDate), toDate,"yyyy-MM-dd")
            .AppendQueryParam(nameof(includeExternalReference), includeExternalReference)
            .AppendQueryParam(nameof(aggregateByDate), aggregateByDate)
            .AppendQueryParam(nameof(aggregateByLevel), aggregateByLevel)
            .AppendQueryParam(nameof(includeChildOrganisations), includeChildOrganisations)
            .AppendQueryParam(nameof(limit), limit)
            .AppendQueryParam(nameof(offset), offset);
            ;
            
        return url;

    }
    
    
}