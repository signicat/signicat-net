using System.Text.Json.Serialization;

namespace Signicat
{
    public class ValidationError
    {
        [JsonPropertyName("name")] public string PropertyName { get; set; }

        [JsonPropertyName("reason")] public string Reason { get; set; }
    }
}