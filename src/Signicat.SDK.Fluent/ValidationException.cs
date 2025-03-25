using System;

namespace Signicat
{
    public class ValidationException : Exception
    {
        public ValidationException(string exceptionMessage) : base(exceptionMessage)
        {
        }
    }
}