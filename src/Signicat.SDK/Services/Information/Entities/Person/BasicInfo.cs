using System.Collections.Generic;

namespace Signicat.Information.Person
{
    public class BasicInfo
    {
        /// <summary>
        /// Names
        /// </summary>
        public IList<PersonName> Names { get; set; }

        public PersonBirth Birth { get; set; }
        
        /// <summary>
        /// Nationalities
        /// </summary>
        public IList<Nationality> Nationalities { get; set; }
        
        /// <summary>
        /// Citizenship's
        /// </summary>
        public IList<Citizenship> Citizenships { get; set; }
        
        /// <summary>
        /// Permanent addresses
        /// </summary>
        public IList<PersonAddress> PermanentAddresses { get; set; }
        
        /// <summary>
        /// Postal address
        /// </summary>
        public IList<PersonAddress> PostalAddresses { get; set; }

        /// <summary>
        /// Foreign address
        /// </summary>
        public IList<PersonAddress> ForeignAddresses { get; set; }
        
        public Metadata Metadata { get; set; }
    }
}