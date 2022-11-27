using System.Collections.Generic;
using System.Text.Json.Serialization;


namespace Signicat
{
    public class SignicatError
    {
        [JsonPropertyName("messagege")]
        public string Message { get; set; }
        
        [JsonPropertyName("code")]
        public string Code { get; set; }
        
        [JsonPropertyName("errors")]
        public IEnumerable<ValidationError> ValidationErrors { get; set; }

        [JsonPropertyName("error")]
        public string OAuthError { get; set; }
        
        [JsonPropertyName("error_description")]
        public string OAuthErrorDescription { get; set; }
    }
}