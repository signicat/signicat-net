
namespace Signicat.Information.Person
{
    public class SearchResult : PagedCollection<SearchItem, Metadata>
    {

    }

    public class SearchItem
    {
        /// <summary>
        /// Id of the entity
        /// </summary>
        public string Id { get; set; }
        
        /// <summary>
        /// Name of the entity
        /// </summary>
        public Name Name { get; set; }
        
        /// <summary>
        /// Country of the entity
        /// </summary>
        public Iso3166 Country { get; set; }
    }
}