using System.Text.Json.Serialization;

namespace Signicat
{
    public class EnterpriseValidationError
    {
        [JsonPropertyName("propertyPath")]
        public string Property{ get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }
    }
}