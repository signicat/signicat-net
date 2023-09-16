using System.Collections.Generic;

namespace Signicat.Services.Signing.Express.Entities
{
    public class DocumentStatusSummary
    {
        public DocumentStatus? DocumentStatus { get; set; }
        
        public List<FileFormat> CompletedPackages { get; set; }
        
        public Dictionary<string, List<FileFormat>> AttachmentPackages { get; set; }
    }
}