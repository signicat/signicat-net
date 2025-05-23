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
        public List<SignerValidations> Validations { get; set; } = new List<SignerValidations>();
    }

    public enum SignerValidations
    {
        NATIONAL_IDENTIFICATION_NUMBER
    }
    
    
}