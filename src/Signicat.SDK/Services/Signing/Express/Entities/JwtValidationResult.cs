using System;

namespace Signicat.Services.Signing.Express.Entities
{
    public class JwtValidationResult
    {
        /// <summary>Whether the JWT is valid.</summary>
        public bool? Valid { get; set; }

        /// <summary>The expiration time on or after which the JWT will not be accepted for processing.</summary>
        public DateTime? Expires { get; set; }

        /// <summary>The JWT payload.</summary>
        public JwtPayload Payload { get; set; }

        /// <summary>Error message explaining reason for a failed validation.</summary>
        public string Error { get; set; }
    }

    public class JwtPayload
    {
        /// <summary>
        /// Account Id
        /// </summary>
        public Guid AccountId { get; set; }

        /// <summary>
        /// Document Id
        /// </summary>
        public Guid DocumentId { get; set; }

        /// <summary>
        /// External document Id
        /// </summary>
        public string ExternalId { get; set; }

        /// <summary>
        /// Signer Id
        /// </summary>
        public Guid SignerId { get; set; }

        /// <summary>
        /// External signer Id
        /// </summary>
        public string ExternalSignerId { get; set; }

        /// <summary>
        /// Error object, will be included on error
        /// </summary>
        public SignError Error { get; set; }

        /// <summary>
        /// Success object, will be included on sign success
        /// </summary>
        public SignSuccess SignSuccess { get; set; }

        /// <summary>
        /// When the jwt expires (ISO 8601)
        /// </summary>
        public DateTime? Expires { get; set; }

        /// <summary>
        /// Set to true if user aborted
        /// </summary>
        public bool? Aborted { get; set; }

        public string ClientIp { get; set; }
        public string UserAgent { get; set; }
    }

    public class SignError
    {
        /// <summary>
        /// Idfy error message
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Idfy error code
        /// </summary>
        public string ErrorCode { get; set; }

        /// <summary>
        /// Eid provider error message
        /// </summary>
        public string EidErrorMessage { get; set; }

        /// <summary>
        /// Eid provider error code
        /// </summary>
        public string EidErrorCode { get; set; }
    }

    public class SignSuccess
    {
        /// <summary>
        /// The unique id retrieved from the signature method provider
        /// </summary>
        public string SignatureMethodUniqueId { get; set; }

        /// <summary>
        /// The signers first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// The signers middle name
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// The signers last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// The signers full name
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// The signers date of birth
        /// </summary>
        public string DateOfBirth { get; set; }

        /// <summary>
        /// The signaturemethod used to sign the document
        /// </summary>
        public SignatureMethod SignatureMethod { get; set; }

        /// <summary>
        /// Signed time (ISO 8601)
        /// </summary>
        public DateTime? SignedTime { get; set; }

        /// <summary>
        /// The mechanism used
        /// </summary>
        public SignatureMechanism Mechanism { get; set; }
    }
}