using System.Collections.Generic;

namespace Signicat.Services.Signing.Sign_v2.Entities
{
    public class PaginatedSigningSessionResponse
    {
        /// <summary>
        /// Number of items per page
        /// </summary>
        public int Limit { get; set; }

        /// <summary>
        /// Page number
        /// </summary>
        public int Offset { get; set; }

        /// <summary>
        /// Number of items in current page
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Total number of items
        /// </summary>
        public int Total { get; set; }

        /// <summary>
        /// List of signing sessions
        /// </summary>
        public List<SigningSession> Data { get; set; }
    }
}