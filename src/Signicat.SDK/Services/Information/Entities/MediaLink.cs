using System;

namespace Signicat.Information
{
    public class MediaLink
    {
        /// <summary>
        /// Title of the content
        /// </summary>
        public string Title { get; set; }
        
        /// <summary>
        /// An excerpt of the content
        /// </summary>
        public string Excerpt { get; set; }
        
        /// <summary>
        /// Url to the content
        /// </summary>
        public string Url { get; set; }
        
        /// <summary>
        /// Date of the content
        /// </summary>
        public DateTimeOffset? Date { get; set; }
    }
}