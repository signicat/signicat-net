namespace Signicat.Authentication
{
    public class MessageTransportProperties
    {
        /// <summary>
        ///     Message level encryption.
        /// </summary>
        public string MessageLevelEncryption { get; set; }

        /// <summary>
        ///     Require HSM signing.
        /// </summary>
        public bool RequireHsmSigning { get; set; }
    }
}