using System.Collections.Generic;
using Newtonsoft.Json;

namespace Signicat
{
    public class SignicatError
    {
        [JsonProperty("message")]
        public string Message { get; set; }
        
        [JsonProperty("code")]
        public string Code { get; set; }
        
        [JsonProperty("errors")]
        public IEnumerable<ValidationError> ValidationErrors { get; set; }

        [JsonProperty("error")]
        public string OAuthError { get; set; }
        
        [JsonProperty("error_description")]
        public string OAuthErrorDescription { get; set; }
    }
}