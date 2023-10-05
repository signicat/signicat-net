using System;
using System.Net;
using Signicat.Infrastructure;

namespace Signicat
{
    public class SignicatException : Exception
    {
        public SignicatException(HttpStatusCode statusCode, SignicatError error, SignicatResponse response,
            string message) :
            base(message ?? $"The server returned status code {(int) statusCode}")
        {
            HttpStatusCode = statusCode;
            Error = error;
            Response = response;
        }

        public HttpStatusCode HttpStatusCode { get; }

        public SignicatResponse Response { get; }

        public SignicatError Error { get; }
    }
}