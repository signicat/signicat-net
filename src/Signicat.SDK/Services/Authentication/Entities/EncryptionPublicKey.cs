using System.Runtime.Serialization;

namespace Signicat.Authentication
{
    /// <summary>
    ///     (optional) Encryption key information for message level encryption.
    /// </summary>
    public class EncryptionPublicKey
    {
        /// <summary>
        /// Key type of the JWK, specifying the cryptographic algorithm family used with the key.
        /// </summary>
        public string Kty { get; set; }

        /// <summary>
        /// Identifies the intended use of the key. Values defined by this specification are sig (signature) and enc (encryption).
        /// </summary>
        public string Use { get; set; }

        /// <summary>
        /// Identifier of the key, serves as a unique identifier for the key.
        /// </summary>
        public string Kid { get; set; }

        /// <summary>
        /// Identifies the cryptographic algorithm family used with the key.
        /// </summary>
        public KeyManagementAlgorithm? Alg { get; set; }

        /// <summary>
        /// The public exponent. Only used if the Kty is RSA.
        /// </summary>
        public string E { get; set; }

        /// <summary>
        /// The modulus, a component that is used in both the encryption and decryption process. Only used if the Kty is RSA.
        /// </summary>
        public string N { get; set; }
    }
}

public enum KeyManagementAlgorithm
{
    [EnumMember(Value = "RSA-OAEP")] RsaOaep = 0,

    [EnumMember(Value = "ECDH-ES")] EcdhEs = 1
}