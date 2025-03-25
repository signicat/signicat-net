using System.Runtime.Serialization;

namespace Signicat.Services.Signing.Express.Entities
{
    public class MerchantSignRequest
    {
        /// <summary>
        /// Base 64 encoded data
        /// </summary>
        public string DataToSign { get; set; }

        /// <summary>
        /// Base 64 encoded xslt (optional)
        /// </summary>
        public string Xslt { get; set; }

        /// <summary>
        /// Format of data (i.e xml)
        /// </summary>
        public MerchantDataFormat DataFormat { get; set; }

        /// <summary>
        /// Data encoding, defaults to isolatin
        /// </summary>
        public MerchantEncodingFormat? DataEncodingFormat { get; set; }

        /// <summary>
        /// The service reference for the signing. Will be used for auditlog, and invoicing
        /// </summary>
        public string ExternalReference { get; set; }

        /// <summary>
        /// Optional, if not set the default setting for the account will be used. For now only norwegian bankId is supported
        /// </summary>
        public MerchantSigningFormat? SigningFormat { get; set; }

        /// <summary>
        /// Set this if a specific department should be invoiced
        /// </summary>
        public string DepartmentId { get; set; }
    }

    public enum MerchantDataFormat
    {
        [EnumMember(Value = "xml")] Xml = 0,
        [EnumMember(Value = "txt")] Txt = 2
    }

    public enum MerchantEncodingFormat
    {
        [EnumMember(Value = "UTF8")] Utf8,
        [EnumMember(Value = "ISOLATIN")] IsoLatin,
    }

    public enum MerchantSigningFormat
    {
        [EnumMember(Value = "use_provider_setting")]
        UseProviderSetting,

        [EnumMember(Value = "no_bankid_seid_sdo")]
        NoBankIdSeidSdo,
    }
}