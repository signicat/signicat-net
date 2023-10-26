namespace Signicat.Authentication
{
    /// <summary>
    ///     Error details.
    /// </summary>
    public class ErrorDetails
    {
        /// <summary>
        ///     The problem type.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        ///     A short, human-readable summary of the problem type.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        ///     A human-readable explanation specific to this occurrence of the problem.	
        /// </summary>
        public string Detail { get; set; }

        /// <summary>
        ///     A short machine readable string indicating the error code.
        /// </summary>
        public string Code { get; set; }
    }
}