using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Signicat.DigitalEvidenceManagement.Entities;
using Signicat.Services.Signing.Express.Entities;

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
                DictionaryKeyPolicy = JsonNamingPolicy.CamelCase,
                PropertyNameCaseInsensitive = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };

            SerializerSettings.Converters.Add(new JsonStringEnumConverterEnumMember<RedirectMode>());
            SerializerSettings.Converters.Add(new JsonStringEnumConverterEnumMember<AttachmentType>());
            SerializerSettings.Converters.Add(new JsonStringEnumConverterEnumMember<AddonSignerType>());
            SerializerSettings.Converters.Add(new JsonStringEnumConverterEnumMember<FileFormat>());
            SerializerSettings.Converters.Add(new JsonStringEnumConverterEnumMember<SignatureMechanism>());
            SerializerSettings.Converters.Add(new JsonStringEnumConverterEnumMember<SignatureMethod>());
            SerializerSettings.Converters.Add(new JsonStringEnumConverterEnumMember<SignaturePackageFormat>());
            SerializerSettings.Converters.Add(new JsonStringEnumConverterEnumMember<DemRecordSearchQueryOperator>());
            SerializerSettings.Converters.Add(new JsonStringEnumConverterEnumMember<DocumentStatus>());
            SerializerSettings.Converters.Add(new JsonStringEnumConverterEnumMember<MerchantDataFormat>());
            SerializerSettings.Converters.Add(new JsonStringEnumConverterEnumMember<MerchantEncodingFormat>());
            SerializerSettings.Converters.Add(new JsonStringEnumConverterEnumMember<MerchantSigningFormat>());
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

        internal static SignicatError Map(this SignicatInternalError error)
        {
            if (error == null)
            {
                return new SignicatError();
            }

            var legacyValidationErrors = new List<ValidationError>();

            if (error.EnterpriseValidationErrors is not null)
            {
                legacyValidationErrors.AddRange(error.EnterpriseValidationErrors.Select(validationError =>
                    new ValidationError() {Reason = validationError.Message, PropertyName = validationError.Property}));
            }

            if (error.ExpressValidationErrors is not null)
            {
                legacyValidationErrors.AddRange(error.ExpressValidationErrors.Select(validationError =>
                    new ValidationError() {Reason = validationError.Message, PropertyName = validationError.Field}));
            }

            return new SignicatError()
            {
                Code = error.Code,
                Type = error.Type,
                Detail = error.Detail,
                Title = error.Title ?? error.Message,
                TraceId = error.TraceId,
                ValidationErrors = legacyValidationErrors.Any()
                    ? error.ValidationErrors.Concat(legacyValidationErrors)
                    : error.ValidationErrors,
                OAuthError = error.OAuthError,
                OAuthErrorDescription = error.OAuthErrorDescription,
            };
        }
    }
}