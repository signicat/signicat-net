namespace Signicat.Information
{
    /// <summary>
    ///     Links for paging
    /// </summary>
    public class PageLinks : Link
    {
        /// <summary>
        ///     Url of the next page
        /// </summary>
        public string Next { get; set; }

        /// <summary>
        ///     Url of the previous page
        /// </summary>
        public string Previous { get; set; }

        /// <summary>
        ///     Url of the first page
        /// </summary>
        public string First { get; set; }
    }
}