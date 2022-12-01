using Signicat.Constants;

namespace Signicat.Authentication
{
    public static class AuthenticationExtensions
    {
        public static bool IsSuccess(this AuthenticationSession session)
        {
            return session.Status == AuthenticationStatuses.Success;
        }
    }
}