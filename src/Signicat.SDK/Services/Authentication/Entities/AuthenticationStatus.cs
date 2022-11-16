using System.Runtime.Serialization;

namespace Signicat.Authentication
{
    
    public class AuthenticationStatus
    {
        public string Value { get; private set; }

        public AuthenticationStatus(string value)
        {
            Value = value;
        }
        
        public static implicit operator string(AuthenticationStatus status)
        {
            return status.Value;
        }

        public static readonly AuthenticationStatus Success = new AuthenticationStatus("SUCCESS");
        public static readonly AuthenticationStatus Error = new AuthenticationStatus("ERROR");
        public static readonly AuthenticationStatus Aborted = new AuthenticationStatus("ABORTED");
    }
    
}