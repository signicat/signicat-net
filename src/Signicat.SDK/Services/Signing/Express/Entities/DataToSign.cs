namespace Signicat.Services.Signing.Express.Entities
{
    public class DataToSign
    {
        /// <summary>
        /// Document title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Document description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Base64-encoded string of the document, UTF-8-encoded.
        /// </summary>
        public string Base64Content { get; set; }

        /// <summary>
        /// Stylesheet to be included if you are uploading XML.
        /// </summary>
        public string Base64ContentStyleSheet { get; set; }

        /// <summary>
        /// The document file name. Must include a valid file extension (.pdf, .xml, .txt, .doc, .docx, .rtf, .ott, odt).
        /// </summary>
        public string FileName { get; set; }

        /// <summary>Determines if the document should be converted to PDF. Supported formats are word documents, rich text format, and OpenOffice (.doc, .docx, .rtf, .odt, .ott).
        /// Remark: When using this, the converted document (and not the original) is the one that will be signed.
        /// </summary>
        public bool? ConvertToPDF { get; set; }

        /// <summary>
        /// Settings for packaging of the signed document.
        /// </summary>
        public Packaging Packaging { get; set; }
    }
}