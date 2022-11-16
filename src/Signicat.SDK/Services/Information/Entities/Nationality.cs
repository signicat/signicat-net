using System;

namespace Signicat.Information
{
    /// <summary>
    /// Nationality of an entity
    /// </summary>
    public class Nationality
    {
        /// <summary>
        /// Is active
        /// </summary>
        public bool IsActive { get; set; }
        
        public Iso3166 Country { get; set; }

        public DateTimeOffset? StartDate { get; set; }
        
        public DateTimeOffset? EndDate { get; set; }
    }
}