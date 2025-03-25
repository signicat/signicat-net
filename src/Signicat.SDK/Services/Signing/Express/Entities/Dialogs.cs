namespace Signicat.Services.Signing.Express.Entities
{
    public class Dialogs
    {
        /// <summary>
        /// A dialog that will be presented before the document is signed.
        /// </summary>
        public DialogBefore Before { get; set; }

        /// <summary>
        /// A dialog that will be presented after the document is signed.
        /// </summary>
        public DialogAfter After { get; set; }
    }
}