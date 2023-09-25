using System.Collections.Generic;

namespace Signicat.Services.Signing.Enterprise.Entities
{
    public class Subject
    {
        
        public string Id { get; set; }

        
        public List<Attribute> Attributes { get; set; }
    }

    public class ClientProblem {


        public int Status { get; set; }
        public string Type { get; set; }

        public string Title { get; set; }

        public string Detail { get; set; }

    }
}
