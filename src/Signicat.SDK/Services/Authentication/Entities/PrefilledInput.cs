namespace Signicat.Authentication
{
    /// <summary>
    /// Prefilled input values.
    /// </summary>
    public class PrefilledInput
    {
        /// <summary>
        /// Prefill the user's national identification number.
        /// </summary>
        public string Nin { get; set; }

        /// <summary>
        /// Prefill the user's mobile number. Must be prefixed with country code.
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// Prefill the user's date of birth (YYYY-MM-DD). For Norwegian BankID on Mobile the DDMMYY format is also supported.
        /// </summary>
        public string DateOfBirth { get; set; }

        /// <summary>
        /// Prefill the user's username.
        /// </summary>
        public string Username { get; set; }
        
        /// <summary>
        /// Prefill the user's email.
        /// </summary>
        public string Email { get; set; }
    }
}
