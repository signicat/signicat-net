using System.Collections.Generic;

namespace Signicat.Information.Geodata
{
    public class CountryInfo
    {
        public string SelfUrl { get; set; }
        
        public string SubdivisionsUrl { get; set; }
        
        public string Continent { get; set; }
        
        public string Capital { get; set; }
        
        public IEnumerable<string> Languages { get; set; }
        
        public string Population { get; set; }
        
        public string CountryCode { get; set; }
        
        public string IsoAlpha3 { get; set; }
        
        public string CountryName { get; set; }
        
        public string ContinentName { get; set; }
        
        public string CurrencyCode { get; set; }
        
        public string IsoNumeric { get; set; }
    }
}