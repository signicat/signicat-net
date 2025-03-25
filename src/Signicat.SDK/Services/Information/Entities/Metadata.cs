using System;
using System.Collections.Generic;

namespace Signicat.Information
{
    /// <summary>
    ///     Metadata about the response
    /// </summary>
    public class Metadata
    {
        /// <summary>
        ///     List of sources for the data
        /// </summary>
        public IList<string> Sources { get; set; }

        /// <summary>
        ///     Public urls to the sources
        /// </summary>
        public IList<string> Urls { get; set; }


        /// <summary>
        ///     The date the data was last changed
        /// </summary>
        public DateTimeOffset? LastChanged { get; set; }

        /// <summary>
        ///     The raw JSON if it was requested and supported by the source
        /// </summary>
        public string RawJson { get; set; }

        /// <summary>
        ///     Defines if data is retrieved from cache or not
        /// </summary>
        public bool IsCache { get; set; }
    }

    /// <summary>
    ///     Metadata about the response
    /// </summary>
    public class OrganizationMetadata : Metadata
    {
        /// <summary>
        ///     Accounting year of the data
        /// </summary>
        public int? AccountingYear { get; set; }
    }
}