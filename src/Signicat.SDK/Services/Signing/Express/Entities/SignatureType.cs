using System.Collections.Generic;

namespace Signicat.Services.Signing.Express.Entities
{
    public class SignatureType
    {
        /// <summary>
        /// A list of signature methods that the signer is allowed to use when signing the document.
        /// If not specified, all available signature methods for your Signicat account will be displayed to the signer.
        /// </summary>
        public List<SignatureMethod> SignatureMethods { get; set; }
        
        public SignatureMechanism Mechanism { get; set; }
        
        public bool? OnEacceptUseHandWrittenSignature { get; set; }
    }
}