using System.Text.Json;
using System.Text.Json.Serialization;

namespace Signicat.Infrastructure
{
    internal static class Mapper
    {
        private static readonly JsonSerializerOptions SerializerSettings;

        static Mapper()
        {
            SerializerSettings = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                DictionaryKeyPolicy = JsonNamingPolicy.CamelCase,
            };

            SerializerSettings.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
        }
        
        public static T MapFromJson<T>(string json)
        {
            return !string.IsNullOrWhiteSpace(json)
                ? JsonSerializer.Deserialize<T>(json, SerializerSettings)
                : default(T);
        }
        
        public static T MapFromJson<T>(SignicatResponse response)
        {
            return MapFromJson<T>(response.ResponseJson);
        }

        public static string MapToJson(object request)
        {
            return JsonSerializer.Serialize(request, SerializerSettings);
        }
    }
}