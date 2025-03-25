using System;

namespace Signicat.Services.Signing.Express.Entities
{
    public class MerchantSignResponse
    {
        /// <summary>
        /// base 64 encoded signed data
        /// </summary>
        public string SignedData { get; set; }

        /// <summary>
        /// Signing format
        /// </summary>
        public MerchantSigningFormat SigningFormat { get; set; }

        /// <summary>
        /// Error message
        /// </summary>
        public MerchantSignError Error { get; set; }

        /// <summary>
        /// Signed with certificate
        /// </summary>
        public string SignCertificateBase64String { get; set; }

        /// <summary>
        /// Id to look up the transaction at a later time
        /// </summary>
        public Guid TransactionId { get; set; }

        public string DepartmentId { get; set; }
        public MerchantEncodingFormat? DataEncodingFormat { get; set; }

        /// <summary>
        /// Format of data (i.e xml)
        /// </summary>
        public MerchantDataFormat DataFormat { get; set; }
    }

    public class MerchantSignError
    {
        public int ErrorCode { get; set; }
        public string ErrorDescription { get; set; }
    }
}