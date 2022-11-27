using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Signicat.Infrastructure
{
    internal static class Mapper
    {
        private static readonly System.Text.Json.JsonSerializerOptions SerializerSettings;

        static Mapper()
        {
            SerializerSettings = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                DictionaryKeyPolicy = JsonNamingPolicy.CamelCase
                //ContractResolver = new CamelCasePropertyNamesContractResolver(),
                
            };

            SerializerSettings.Converters.Add(new JsonStringEnumConverter());
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