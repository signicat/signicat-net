using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Signicat.Infrastructure
{
    public class UpperCaseNamingPolicy : JsonNamingPolicy
    {
        public override string ConvertName(string name)
        {
            return name.ToUpper();
        }
    }
    
    public class DateTimeConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return DateTime.SpecifyKind(DateTime.Parse(reader.GetString()), DateTimeKind.Unspecified);
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {          
            writer.WriteStringValue(DateTime.SpecifyKind(value, DateTimeKind.Unspecified));
        }
    }
}