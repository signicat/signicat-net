using System;

namespace Signicat.Services.Signing.Express.Entities
{
    public class TimeToLive
    {
        /// <summary>
        /// Time at which the document will expire (ISO 8601). The document can not be signed after this time. Default/maximum 45 days.
        /// </summary>
        public DateTime? Deadline { get; set; }
    
        /// <summary>
        /// How many hours we will keep the document after it is signed or expired (deadline). Default/ maximum 7 days (168 hours). After this timespan the document and files will be permanently deleted on our side.
        /// </summary>
        public int? DeleteAfterHours { get; set; }
    }
}