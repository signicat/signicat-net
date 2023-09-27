using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Signicat.Authentication
{
    /// <summary>
    ///     Details about the identified user. Only available if session has status `success`.
    /// </summary>
    public class Subject
    {
        /// <summary>
        ///     The identifier of the subject.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        ///     The idp identifier of the subject.
        /// </summary>
        public string IdpId { get; set; }

        /// <summary>
        ///     First name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        ///     Last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        ///     Date of birth.
        /// </summary>
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        ///     National identification number.
        /// </summary>
        public Nin Nin { get; set; }
        
        /// <summary>
        /// Additional attributes from the Id provider
        /// </summary>
        [JsonExtensionData]
        public IDictionary<string, JsonElement> IdpAttributes { get; set; }
    }
}