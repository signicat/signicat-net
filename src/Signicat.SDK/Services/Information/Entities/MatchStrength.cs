using System.Runtime.Serialization;

namespace Signicat.Information
{
    /// <summary>
    ///     An indication of how relevant the result is
    /// </summary>
    public class MatchStrength
    {
        /// <summary>
        ///     A score from 0 - 100 where higher values are more relevant
        /// </summary>
        public int? Score { get; set; }

        /// <summary>
        ///     Used if an exact score is unavailable
        /// </summary>
        public MatchCertainty Certainty { get; set; }
    }

    public enum MatchCertainty
    {
        [EnumMember(Value = "unknown")] Unknown = 0,

        [EnumMember(Value = "high")] High = 1,

        [EnumMember(Value = "medium")] Medium = 2,

        [EnumMember(Value = "low")] Low = 3
    }
}