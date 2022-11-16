using System.Runtime.Serialization;

namespace Signicat.Authentication
{
    
    public class Language
    {
        public string Value { get; private set; }

        public Language(string value)
        {
            Value = value;
        }
        
        public static implicit operator string(Language language)
        {
            return language.Value;
        }

        public static readonly Language Norwegian = new Language("no");
        public static readonly Language English = new Language("en");
        public static readonly Language Swedish = new Language("sv");
        public static readonly Language Danish = new Language("da");
        public static readonly Language Finnish = new Language("fi");
        public static readonly Language Dutch = new Language("nl");
    }
    
   
}