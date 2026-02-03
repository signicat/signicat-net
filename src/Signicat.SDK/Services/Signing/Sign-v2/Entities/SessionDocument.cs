using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Signicat.Services.Signing.Sign_v2.Entities
{
    /// <summary>
    /// Document in a signing session
    /// </summary>
    public class SessionDocument
    {
        public SessionDocument()
        {
        }

        public SessionDocument(string documentCollectionId, SessionDocumentAction action, string documentId)
        {
            DocumentCollectionId = documentCollectionId;
            Action = action;
            DocumentId = documentId;
        }

        /// <summary>
        /// ID of the document collection
        /// </summary>
        /// <example>f05d0dce-a7af-432b-b6b8-e455ab7c0853</example>
        public string DocumentCollectionId { get; set; }

        /// <summary>
        /// Action to perform on the document
        /// </summary>
        /// <example>SIGN</example>
        public SessionDocumentAction Action { get; set; }

        /// <summary>
        /// ID of the document
        /// </summary>
        /// <example>f05d0dce-a7af-432b-b6b8-e455ab7c0857</example>
        public string DocumentId { get; set; }
    }

    /// <summary>
    /// Document actions in a signing session
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverterEnumMember<SessionDocumentAction>))]
    public enum SessionDocumentAction
    {
        /// <summary>
        /// View the document
        /// </summary>
        [EnumMember(Value = "VIEW")] VIEW,

        /// <summary>
        /// Sign the document
        /// </summary>
        [EnumMember(Value = "SIGN")] SIGN
    }
}