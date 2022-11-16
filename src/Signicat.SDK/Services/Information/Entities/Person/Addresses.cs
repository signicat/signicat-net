using System;
using System.Collections.Generic;
using System.Linq;

namespace Signicat.Information.Person
{
    /// <summary>
    /// Address information
    /// </summary>
    public class PersonAddress : Address
    {
        /// <summary>
        /// If the address is active
        /// </summary>
        public bool IsActive { get; set; }
        
        /// <summary>
        /// If the address is confidential
        /// </summary>
        public bool IsConfidential { get; set; }
        
        /// <summary>
        /// Start date of the address
        /// </summary>
        public DateTimeOffset? StartDate { get; set; }
        
        /// <summary>
        /// End date of the address
        /// </summary>
        public DateTimeOffset? EndDate { get; set; }

        /// <summary>
        /// Address lines if the source contains unstructured data
        /// </summary>
        public IList<string> AddressLines { get; set; }
    }
}