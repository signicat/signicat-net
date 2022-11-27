using System.Text.Json.Serialization;

namespace Signicat
{
    public class ValidationError
    {
        [JsonPropertyName("field")]
        public string Field { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }
    }
}