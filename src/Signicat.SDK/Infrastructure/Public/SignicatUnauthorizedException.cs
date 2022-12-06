using System.Net;

namespace Signicat
{
    public class SignicatUnauthorizedException : SignicatException
    {
        public SignicatUnauthorizedException(HttpStatusCode statusCode, SignicatError error, SignicatResponse response,
            string message) : base(statusCode, error, response, message)
        {
        }
    }
}