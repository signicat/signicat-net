using System.Runtime.Serialization;

namespace Signicat.Authentication
{
    public class AllowedProviderTypes
    {
        public string Value { get; private set; }

        public AllowedProviderTypes(string value)
        {
            Value = value;
        }
        
        public static implicit operator string(AllowedProviderTypes allowedProviderTypes)
        {
            return allowedProviderTypes.Value;
        }

        public static readonly AllowedProviderTypes NorwegianBankId = new AllowedProviderTypes("nbid");
        public static readonly AllowedProviderTypes SwedishBankID = new AllowedProviderTypes("sbid");
    }
    
  
}
