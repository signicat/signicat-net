using System.Net;

namespace Signicat
{
    /// <summary>
    /// If the client is authenticated but does not have the correct permission/role for this account or operation
    /// </summary>
    public class SignicatForbiddenException : SignicatException
    {
        public SignicatForbiddenException(HttpStatusCode statusCode, SignicatError error, SignicatResponse response, string message) : base(statusCode, error, response, message)
        {
        }
    }
}