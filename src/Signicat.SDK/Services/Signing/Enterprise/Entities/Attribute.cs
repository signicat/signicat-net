using System.Collections.Generic;

namespace Signicat.Services.Signing.Enterprise.Entities
{
    public class Attribute
    {
        public string Name { get; set; }
        
        public string Value { get; set; }
        
        public List<string> Methods { get; set; }
    }
}
