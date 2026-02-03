using System.Collections.Generic;

namespace Signicat.Services.Signing.Sign_v2.Entities
{
    /// <summary>
    /// Represents a signer
    /// </summary>
    public class Signer
    {
        /// <summary>
        /// National identification number of the signer
        /// </summary>
        public string NationalIdentificationNumber { get; set; }

        /// <summary>
        /// Validations to perform on the signer
        /// </summary>
        public List<SignerValidation> Validations { get; set; } = new List<SignerValidation>();

        /// <summary>
        /// Restrict use of a specific parameter for a signer. If restriction is set to NO_USE, the parameter will not be requested from the IdP and will not be included in the signature.
        /// </summary>
        public List<RestrictUse> RestrictUse { get; set; }
    }

    public class RestrictUse
    {
        /// <summary>
        ///
        ///<example>NIN</example>
        /// </summary>
        public RestrictUseParameter Parameter { get; set; }

        /// <summary>
        ///
        ///<example>NO_USE</example>
        /// </summary>
        public Restriction Restriction { get; set; }
    }

    public enum SignerValidation
    {
        NATIONAL_IDENTIFICATION_NUMBER
    }

    public enum RestrictUseParameter
    {
        NIN
    }

    public enum Restriction
    {
        NO_USE
    }
}