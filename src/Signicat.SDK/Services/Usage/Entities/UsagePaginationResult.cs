using System.Collections.Generic;

namespace Signicat.Entities;

public record UsagePaginationResult
{
    /// <summary>
    /// List of Usage items 
    /// </summary>
    public IEnumerable<UsageItem> Data { get; set; }

    /// <summary>
    /// Next pointer
    /// </summary>
    public string Next { get; set; }
}