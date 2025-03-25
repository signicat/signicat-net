using System.Collections.Generic;

namespace Signicat.Services.Signing.Express.Entities
{
    /// <summary>
    /// Security settings.
    /// </summary>
    public class Security
    {
        /// <summary>
        /// (Coming soon) Determines if the link is one-time use.
        /// </summary>
        public bool? OneTimeUse { get; set; }

        /// <summary>
        /// (Coming soon) A list of IP addresses that are allowed to see / sign the document.
        /// </summary>
        public List<string> IpWhiteList { get; set; }
    }
}