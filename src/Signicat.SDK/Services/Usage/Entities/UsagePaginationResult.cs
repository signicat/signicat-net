#nullable enable
using System.Collections.Generic;
using Signicat.Services.Usage.Entities;

namespace Signicat.Entities
{
    public record UsagePaginationResult
    {
        /// <summary>
        /// List of Usage items 
        /// </summary>
        public IEnumerable<UsageData> Data { get; set; } = new List<UsageData>();

        /// <summary>
        /// Next pointer
        /// <remarks>Url to next page in the set. Null if on first page</remarks>
        /// </summary>
        public string? Next { get; set; }

        /// <summary>
        /// Previous pointer
        /// <remarks>Url to previous page in the set. Null if on first page</remarks>
        /// </summary>
        public string? Previous { get; set; }
    }
}