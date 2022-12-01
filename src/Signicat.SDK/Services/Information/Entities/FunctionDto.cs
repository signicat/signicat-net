using System;

namespace Signicat.Information
{
    public class FunctionDto
    {
        /// <summary>
        ///     Start date
        /// </summary>
        public DateTimeOffset? StartDate { get; set; }

        /// <summary>
        ///     End date
        /// </summary>
        public DateTimeOffset? EndDate { get; set; }

        /// <summary>
        ///     Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Type of function
        /// </summary>
        public string Function { get; set; }
    }
}