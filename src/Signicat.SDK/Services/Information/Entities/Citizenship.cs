using System;

namespace Signicat.Information
{
    public class Citizenship
    {
        /// <summary>
        ///     Country codes
        /// </summary>
        public Iso3166 Country { get; set; }

        public bool IsActive { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}