using System;

namespace Signicat
{
    public class SignicatResponse
    {
        /// <summary>
        /// The raw JSON returned by Signicat.
        /// </summary>
        public string ResponseJson { get; set; }

        /// <summary>
        /// The date and time at which the request was made.
        /// </summary>
        public DateTime RequestDate { get; set; }
    }
}