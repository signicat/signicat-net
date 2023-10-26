using System;

namespace Signicat.Constants
{
    [Serializable]
    public static class AllowedProviderTypes
    {
        /// <summary>
        ///     Norwegian BankID
        /// </summary>
        public const string NorwegianBankId = "nbid";

        /// <summary>
        ///     Swedish BankID
        /// </summary>
        public const string SwedishBankID = "sbid";
        
        /// <summary>
        ///     Danish MitId
        /// </summary>
        public const string MitId = "mitid";
        
        /// <summary>
        ///     Finnish Trust Network
        /// </summary>
        public const string FinnishTrustNetwork = "ftn";

        /// <summary>
        ///     iDIN
        /// </summary>
        public const string iDIN = "idin";

        /// <summary>
        ///     DigiD
        /// </summary>
        public const string DigiD = "digid";

        /// <summary>
        ///     EHerkenning
        /// </summary>
        public const string EHerkenning = "eherkenning";
    }
}