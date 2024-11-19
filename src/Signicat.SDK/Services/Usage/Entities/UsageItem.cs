#nullable enable

namespace Signicat.Entities;

public record UsageItem
{
    public string? ExternalReference { get; set; }

    public double Count { get; set; }

    public string State { get; set; }

    public string UsageType { get; set; }

    public string UnitOfMeasure { get; set; }

    public bool Invoiced { get; set; }

    public string ProductName { get; set; }

    public  string? AccountId { get; set; }

    
    public string OrganisationId { get; set; }
}