namespace Signicat.Constants
{
    public static class RequestedAttributes
    {
        /// <summary>
        /// Get the Firstname for the person authenticating
        /// </summary>
        public const string FirstName = "firstName";

        /// <summary>
        /// Get the Lastname for the person authenticating
        /// </summary>
        public const string LastName = "lastName";
        
        /// <summary>
        /// Get the Date of birth for the person authenticating
        /// </summary>
        public const string DateOfBirth = "dateOfBirth";

        /// <summary>
        /// Get the Nation identification number, also known as social security number. for the person authenticating 
        /// </summary>
        public const string NationalIdentifierNumber = "nin";


    }
}