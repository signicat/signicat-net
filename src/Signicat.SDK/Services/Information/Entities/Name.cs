using System.Runtime.Serialization;

namespace Signicat.Information
{
    /// <summary>
    ///     Name of the entity
    /// </summary>
    public class Name
    {
        public NameStatus Status { get; set; }

        /// <summary>
        ///     Full name of the entity
        /// </summary>
        public string Full { get; set; }

        /// <summary>
        ///     First/given name of the entity
        /// </summary>
        public string First { get; set; }

        /// <summary>
        ///     Last/surname of the entity
        /// </summary>
        public string Last { get; set; }

        /// <summary>
        ///     Middle name of the entity
        /// </summary>
        public string Middle { get; set; }
    }

    /// <summary>
    ///     A hint to which attributes are set.
    ///     `partial` : only full name,
    ///     `all` : all attributes.
    /// </summary>
    public enum NameStatus
    {
        /// <summary>
        ///     Only a full name was found
        /// </summary>
        [EnumMember(Value = "partial")] Partial,

        /// <summary>
        ///     All name attributes are set
        /// </summary>
        [EnumMember(Value = "all")] All
    }
}