using System.Text.Json.Serialization;

namespace Signicat
{
    public class ExpressValidationError
    {
        [JsonPropertyName("field")]
        public string Field { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }
    }
}