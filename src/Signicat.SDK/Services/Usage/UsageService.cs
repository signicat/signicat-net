using System;
using System.Threading.Tasks;
using Signicat.Entities;
using Signicat.Infrastructure;


namespace Signicat.Services.Usage;

public class UsageService(string organisationId) : SignicatBaseService(organisationId), IUsageService
{
    public Task<UsagePaginationResult> GetUsageAsync( string next, int limit = 100)
    {
        return GetAsync<UsagePaginationResult>($"{Urls.UsageTransactions}?next={next}&limit={limit}");
    }

    public Task<UsagePaginationResult> GetUsageAsync(DateTime fromDate,
        DateTime? toDate = null,
        bool includeExternalReference = false, AggregateByDates? aggregateByDate = null,
        AggregateByLevel? aggregateByLevel = null, bool includeChildOrganisations = false, int limit = 100)
    {
        return GetAsync<UsagePaginationResult>(BuildUrl(fromDate, toDate, includeExternalReference, aggregateByDate,
            aggregateByLevel, includeChildOrganisations, limit));
    }

    public UsagePaginationResult GetUsage(  string next, int limit = 100)
    {
        return Get<UsagePaginationResult>($"{Urls.UsageTransactions}?next={next}&limit={limit}");
    }

    public UsagePaginationResult GetUsage(DateTime fromDate, DateTime? toDate = null,
        bool includeExternalReference = false, AggregateByDates? aggregateByDate = null,
        AggregateByLevel? aggregateByLevel = null, bool includeChildOrganisations = false, int limit = 100)
    {
        return Get<UsagePaginationResult>(BuildUrl(fromDate, toDate, includeExternalReference, aggregateByDate,
            aggregateByLevel, includeChildOrganisations, limit));
    }

    internal static string BuildUrl(DateTime fromDate, DateTime? toDate = null,
        bool includeExternalReference = false, AggregateByDates? aggregateByDate = null,
        AggregateByLevel? aggregateByLevel = null, bool includeChildOrganisations = false, int limit = 100)
    {

        return $"{Urls.UsageTransactions}"
            .AppendQueryParam(nameof(fromDate), fromDate, "YYYY-MM-DD")
            .AppendQueryParam(nameof(toDate), toDate,"YYYY-MM-DD")
            .AppendQueryParam(nameof(includeExternalReference), includeExternalReference)
            .AppendQueryParam(nameof(aggregateByDate), aggregateByDate)
            .AppendQueryParam(nameof(aggregateByLevel), aggregateByLevel)
            .AppendQueryParam(nameof(includeChildOrganisations), includeChildOrganisations);


    }
}