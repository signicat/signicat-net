using System;

namespace Signicat.Information.Person
{
    public class PersonName : Name
    {
        /// <summary>
        /// If the name is active
        /// </summary>
        public bool IsActive { get; set; }
        
        /// <summary>
        /// Start date of the name
        /// </summary>
        public DateTimeOffset? StartDate { get; set; }
        
        /// <summary>
        /// End date of the name
        /// </summary>
        public DateTimeOffset? EndDate { get; set; }
    }
}