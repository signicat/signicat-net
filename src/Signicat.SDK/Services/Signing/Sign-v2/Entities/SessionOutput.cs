using System.Collections.Generic;

namespace Signicat.Services.Signing.Sign_v2.Entities
{
    /// <summary>
    /// Contains session output information
    /// </summary>
    public class SessionOutput
    {
        /// <summary>
        /// Signatures in the session
        /// </summary>
        public List<SessionSignature> Signatures { get; set; } = new List<SessionSignature>();

        /// <summary>
        /// Packages in the session
        /// </summary>
        public List<SessionPackage> Packages { get; set; } = new List<SessionPackage>();
    }
}
