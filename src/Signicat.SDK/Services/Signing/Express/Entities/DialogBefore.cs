using System.Collections.Generic;

namespace Signicat.Services.Signing.Express.Entities
{
    public class DialogBefore
    {
        /// <summary>
        /// Determines if a the user must confirm that the dialog message has been read before they can continue.
        /// </summary>
        public bool? UseCheckBox { get; set; }

        /// <summary>
        /// The title of the dialog.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The message body of the dialog.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// List of input fields presented to signer.
        /// </summary>
        public List<FormField> FormFields { get; set; }
    }
}