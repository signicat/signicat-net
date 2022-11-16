using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace Signicat.Infrastructure
{
    internal static class Mapper
    {
        private static readonly JsonSerializerSettings SerializerSettings;

        static Mapper()
        {
            SerializerSettings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            SerializerSettings.Converters.Add(new StringEnumConverter());
        }
        
        public static T MapFromJson<T>(string json)
        {
            return !string.IsNullOrWhiteSpace(json)
                ? JsonConvert.DeserializeObject<T>(json, SerializerSettings)
                : default(T);
        }
        
        public static T MapFromJson<T>(SignicatResponse response)
        {
            return MapFromJson<T>(response.ResponseJson);
        }

        public static string MapToJson(object request)
        {
            return JsonConvert.SerializeObject(request, SerializerSettings);
        }
    }
}