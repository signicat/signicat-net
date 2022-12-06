using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Signicat
{
    public class SignicatError
    {
        /// <summary>
        ///     Short human readable summary of the error
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }

        /// <summary>
        ///     A short machine readable string indicating the error code. Should be constant.
        /// </summary>
        [JsonPropertyName("code")]
        public string Code { get; set; }

        /// <summary>
        ///     A human-readable explanation specific to this occurrence of the problem.
        /// </summary>
        [JsonPropertyName("detail")]
        public string Detail { get; set; }

        /// <summary>
        ///     Uri to the documentation that describes this error
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        ///     TraceId to be used for support request
        /// </summary>
        [JsonPropertyName("traceId")]
        public string TraceId { get; set; }

        [JsonPropertyName("errors")] public Dictionary<string, string[]> Errors { get; set; }

        /// <summary>
        ///     List of parameters that are invalid both name and reason.
        /// </summary>
        [JsonPropertyName("invalidParams")]
        public IEnumerable<ValidationError> ValidationErrors { get; set; }

        [JsonPropertyName("error")] public string OAuthError { get; set; }

        [JsonPropertyName("error_description")]
        public string OAuthErrorDescription { get; set; }
    }
}