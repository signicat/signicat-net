namespace Signicat.Services.Sign.Entities
{
    /// <summary>
    /// Archive settings
    /// </summary>
    public class ArchiveSettings
    {
        /// <summary>
        /// Whether to send the original document to the archive
        /// </summary>
        public bool SendOriginalToArchive { get; set; }
        
        /// <summary>
        /// Whether to send the result document to the archive
        /// </summary>
        public bool SendResultToArchive { get; set; }
    }
}