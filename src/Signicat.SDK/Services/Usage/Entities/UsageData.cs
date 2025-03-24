#nullable enable

namespace Signicat.Services.Usage.Entities;

public record UsageData
{
    /// <summary>
    /// External reference, if supplied. Will be null unless explicitly requested
    /// </summary>
    /// <example>orderid:13412</example>
    public string? ExternalReference { get; set; }

    /// <summary>
    /// Total value for this usage
    /// <example>100</example>
    /// </summary>
    public double Count { get; set; }

    /// <summary>
    /// Final state of usage
    /// <example>"completed" "started" "loaded" "userAborted" "failed"</example>
    /// </summary>
    public UsageState State { get; set; }

    /// <summary>
    /// Name of emitted event
    /// <example>"srn:sue:1:authbroker:nbid:auth:bidbax</example>
    /// </summary>
    public string UsageType { get; set; }

    /// <summary>
    /// The unit for the Count field
    /// <example>Authentications</example>
    /// </summary>
    public string? UnitOfMeasure { get; set; }

    /// <summary>
    /// Is this usage invoiced
    /// </summary>
    /// <example>true</example>
    /// <remarks>Set to true if this usage is invoiced. Typically Failed usage is reported but not invoiced</remarks>
    public bool Invoiced { get; set; } = false;

    /// <summary>
    /// Name of product shown on invoice where usage is potentially invoiced
    /// </summary>
    /// <example>Norwegian BankId - Authentications</example>
    public string? ProductName { get; set; }

    /// <summary>
    /// Id of account where usage is produced.
    /// </summary>
    /// <remarks>Will be null if aggregation level is organisation</remarks>
    /// <example>a-ppge-jkQaJ4Od2e5giZh1BiSp</example>
    public string? AccountId { get; set; }
    
    /// <summary>
    /// Id of organisation owning the account where usage is produced
    /// <example>o-p-8gcrvJvHZ3cYZKrAsmQp</example>
    /// </summary>
    public string OrganisationId { get; set; }

    /// <summary>
    /// Period of dates
    /// </summary>
    public Periode Periode { get; set; } = new Periode();
}