using System;
using System.Collections.Generic;

namespace Signicat.Services.Signing.Sign_v2.Entities
{
    public class SigningSessionListOptions
    {
        /// <summary>
        /// Number of rows to skip before returning results.
        /// </summary>
        public int? Offset { get; set; }

        /// <summary>
        /// Maximum number of rows to return.
        /// </summary>
        public int? Limit { get; set; }

        /// <summary>
        /// Sorting field. Default value is -createdAt. E.g., +dueDate
        /// </summary>
        public List<string> Sort { get; set; }

        /// <summary>
        /// Filter signing sessions created on or after this date and time
        /// </summary>
        public DateTime? CreatedDateFrom { get; set; }

        /// <summary>
        /// Filter signing sessions created on or before this date and time
        /// </summary>
        public DateTime? CreatedDateTo { get; set; }

        /// <summary>
        /// Search field for state. Multiple values allowed. E.g., BLOCKED, READY.
        /// </summary>
        public List<SessionState> State { get; set; }

        /// <summary>
        /// Filter signing sessions with due date on or after this date and time
        /// </summary>
        public DateTime? DueDateFrom { get; set; }

        /// <summary>
        /// Filter signing sessions with due date on or before this date and time
        /// </summary>
        public DateTime? DueDateTo { get; set; }

        /// <summary>
        /// Filter signing sessions by title using partial text matching (case-insensitive)
        /// </summary>
        public string SessionTitleLike { get; set; }
    }
}