
namespace Signicat.Information
{
    public class PagedCollection<T, TMetadata>
    {
        /// <summary>
        /// The offset of the current page.
        /// </summary>
        /// <value>The offset of the current page.</value>
        public int Offset { get; set; }

        /// <summary>
        /// The limit of the current paging options.
        /// </summary>
        /// <value>The limit of the current paging options.</value>
        public int Limit { get; set; }

        /// <summary>
        /// The total size of the collection (irrespective of any paging options).
        /// </summary>
        /// <value>The total size of the collection.</value>
        public long Size { get; set; }

        public PageLinks Links { get; set; }
        
        /// <summary>
        /// The result data
        /// </summary>
        public T[] Data { get; set; }
        
        public TMetadata Metadata { get; set; }
    }
}