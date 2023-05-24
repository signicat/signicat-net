using System.Text.Json;
using System.Text.Json.Serialization;
using Signicat.DigitalEvidenceManagement.Entities;

namespace Signicat.Infrastructure
{
    internal static class Mapper
    {
        private static readonly JsonSerializerOptions SerializerSettings;

        static Mapper()
        {
            SerializerSettings = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                DictionaryKeyPolicy = JsonNamingPolicy.CamelCase
            };

            SerializerSettings.Converters.Add(new JsonStringEnumConverterEnumMember<DemRecordSearchQueryOperator>());
            SerializerSettings.Converters.Add(new JsonStringEnumConverter(new UpperCaseNamingPolicy()));
            
        }

        public static T MapFromJson<T>(string json)
        {
            if (string.IsNullOrWhiteSpace(json) ||
                (!json.TrimStart().StartsWith("{") && !json.TrimStart().StartsWith("["))
                || (!json.TrimEnd().EndsWith("}") && !json.TrimEnd().EndsWith("]"))
               )
            {
                return default(T);
            }

            return !string.IsNullOrWhiteSpace(json)
                ? JsonSerializer.Deserialize<T>(json, SerializerSettings)
                : default;
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

