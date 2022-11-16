namespace Signicat.Information
{
    /// <summary>
    /// Organization numbers in different formats
    /// </summary>
    public class OrganizationNumber
    {
        /// <summary>
        /// The domestic organization number
        /// </summary>
        public string Domestic { get; set; }
    
        /// <summary>
        /// Data Universal Numbering System (DUNS number) for the organization. https://en.wikipedia.org/wiki/Data_Universal_Numbering_System
        /// </summary>
        public string DunsNumber  { get; set; }
    
        /// <summary>
        /// Legal Entity Identifier (LEI) - global identifier of legal entities participating in financial transactions. https://en.wikipedia.org/wiki/Legal_Entity_Identifier
        /// </summary>
        public string LegalEntityIdentifier  { get; set; }
    }
}