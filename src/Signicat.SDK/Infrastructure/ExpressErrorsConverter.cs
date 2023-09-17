using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Signicat;

public class SignicatErrorConverter : JsonConverter<SignicatError>
{
    public override SignicatError Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.StartObject)
        {
            throw new JsonException();
        }

        var response = new SignicatError();
        while (reader.Read())
        {
            if (reader.TokenType == JsonTokenType.PropertyName)
            {
                var propertyName = reader.GetString();
                if (propertyName == "errors")
                {
                    reader.Read(); // Move to the value

                    // Attempt to deserialize to deserialize as Dictionary<string, string[]>
                    try
                    {
                        response.Errors = JsonSerializer.Deserialize<Dictionary<string, string[]>>(ref reader, options);
                        continue;
                    }
                    catch { }
                    
                    // If it fails attempt to deserialize to express exception
                    response.ExpressValidationErrors = JsonSerializer.Deserialize<IEnumerable<ExpressValidationError>>(ref reader, options);
                }
            }
        }

        return response;
    }

    public override void Write(Utf8JsonWriter writer, SignicatError value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();

        if (value.ValidationErrors != null)
        {
            writer.WritePropertyName("errors");
            JsonSerializer.Serialize(writer, value.ValidationErrors, options);
        }
        else if (value.Errors != null)
        {
            writer.WritePropertyName("errors");
            JsonSerializer.Serialize(writer, value.Errors, options);
        }

        writer.WriteEndObject();
    }
}
