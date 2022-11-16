
namespace Signicat.Information.Organization
{
    public class SearchResult : PagedCollection<SearchItem, Metadata>
    {
    }
    
    public class SearchItem
    {
        /// <summary>
        /// Organization number
        /// </summary>
        public string OrganizationNumber { get; set; }
        
        /// <summary>
        /// Tax number of the entity (can be: TAX number, VAT number or Tax Identification Number (TIN))
        /// </summary>
        public string TaxNumber { get; set; }
        
        /// <summary>
        /// External Id of the entity (internal source id)
        /// </summary>
        public string ExternalId { get; set; }
        
        /// <summary>
        /// Name of the entity
        /// </summary>
        public string Name { get; set; }
        
        public Link Links { get; set; }

        public Iso3166 Country { get; set; }

        public Address Address { get; set; }
    }
}