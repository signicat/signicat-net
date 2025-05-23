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
        public List<string> Validations { get; set; } = new List<string>();
    }
    
    /// <summary>
    /// Signer validation types
    /// </summary>
    public static class SignerValidationValues
    {
        /// <summary>
        /// Validate the national identification number
        /// </summary>
        public const string NationalIdentificationNumber = "national_identification_number";
    }
}