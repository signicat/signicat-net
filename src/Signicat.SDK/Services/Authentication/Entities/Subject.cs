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
        ///     The first name of the subject.
        /// </summary>
        public string FirstName { get; set; }
        
        /// <summary>
        ///     The middle name of the subject.
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        ///     The last name of the subject.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        ///     The date of birth of the subject.
        /// </summary>
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        ///     National identification number.
        /// </summary>
        public Nin Nin { get; set; }
        
        /// <summary>
        ///     The additional parameters of the subject.
        /// </summary>
        [JsonExtensionData]
        public IDictionary<string, JsonElement> IdpAttributes { get; set; }

        /// <summary>
        ///     The email of the subject.
        /// </summary>
        public string Email { get; set; }
    }
}