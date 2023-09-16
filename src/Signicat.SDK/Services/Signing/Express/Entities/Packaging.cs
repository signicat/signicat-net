using System.Collections.Generic;

namespace Signicat.Services.Signing.Express.Entities
{
    public class Packaging
    {
        /// <summary>
        /// A list of signature formats that will be created and made available for download after the document is signed.
        /// See our documentation for more information about these formats. The native package format is included automatically (i.e. BankID SDO).
        /// </summary>
        public List<SignaturePackageFormat> SignaturePackageFormats { get; set; }
    
        /// <summary>
        /// PAdES settings that can be defined if the `"pades"` package format is selected.
        /// </summary>
        public PadesSettings PadesSettings { get; set; }
    }
}