using Newtonsoft.Json;

namespace Signicat
{
    public class ValidationError
    {
        [JsonProperty("field")]
        public string Field { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}