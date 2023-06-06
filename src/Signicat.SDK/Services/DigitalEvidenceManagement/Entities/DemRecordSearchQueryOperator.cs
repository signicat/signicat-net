using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Signicat.DigitalEvidenceManagement.Entities
{
    [JsonConverter(typeof(JsonStringEnumConverterEnumMember<DemRecordSearchQueryOperator>))]
    public enum DemRecordSearchQueryOperator
    {
        /// <summary>
        ///     Checks if the field's value matches the input value exactly.
        /// </summary>
        [EnumMember(Value = "eq")] Equal,

        /// <summary>
        ///     Checks if the field's value does not match the input value.
        /// </summary>
        [EnumMember(Value = "ne")] NotEqual,

        /// <summary>
        ///     Checks if the field's value is greater than the input value. Works best with numeric values.
        /// </summary>
        [EnumMember(Value = "gt")] GreaterThen,

        /// <summary>
        ///     Checks if the field's value is greater than or equal to the input value. Works best with numeric values.
        /// </summary>
        [EnumMember(Value = "gte")] GreaterThenOrEqual,

        /// <summary>
        ///     Checks if the field's value is less than the input value. Works best with numeric values.
        /// </summary>
        [EnumMember(Value = "le")] LessThen,

        /// <summary>
        ///     Checks if the field's value is less than or equal to the input value. Works best with numeric values.
        /// </summary>
        [EnumMember(Value = "lte")] LessThenOrEqual,

        /// <summary>
        ///     Checks if the field's value contains the input value using regex. Works best with String values.
        /// </summary>
        [EnumMember(Value = "regex")] Regex,

        /// <summary>
        ///     Checks if the field's value matches any of the values in the inputted array.
        /// </summary>
        [EnumMember(Value = "in")] In,

        /// <summary>
        ///     Checks if the field's value does not match any of the values in the inputted array.
        /// </summary>
        [EnumMember(Value = "nin")] NotIn
    }
}