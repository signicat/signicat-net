namespace Signicat.Services.Signing.Express.Entities
{
    /// <summary>
    /// A list of questions presented to signer before signing the document.
    /// </summary>
    public class FormField
    {
        /// <summary>
        /// Description of the form field visible to the signer.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Key describing the form field.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// The type of input in this form field. Can be either text or a checkbox.
        /// </summary>
        public FormType? Type { get; set; }

        /// <summary>
        /// Regex for validating input in form field. Should begin with /^ and end with $/
        /// </summary>
        public string Regex { get; set; }

        /// <summary>
        /// If input is required in the form field before continuing.
        /// </summary>
        public bool Required { get; set; }
    }
}