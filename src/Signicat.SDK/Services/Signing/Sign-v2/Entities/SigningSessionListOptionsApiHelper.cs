using System.Collections.Generic;
using System.Globalization;

namespace Signicat.Services.Signing.Sign_v2.Entities
{
    public static class SigningSessionListOptionsApiHelper
    {
        public static Dictionary<string, object> ToQueryParams(this SigningSessionListOptions options)
        {
            if (options == null)
            {
                return new Dictionary<string, object>();
            }

            var queryParams = new Dictionary<string, object>();

            if (options.Offset.HasValue)
            {
                queryParams.Add("offset", options.Offset.Value);
            }

            if (options.Limit.HasValue)
            {
                queryParams.Add("limit", options.Limit.Value);
            }

            if (options.Sort?.Count > 0)
            {
                queryParams.Add("sort", string.Join(",", options.Sort));
            }

            if (options.CreatedDateFrom.HasValue)
            {
                queryParams.Add("createdDateFrom", options.CreatedDateFrom);
            }

            if (options.CreatedDateTo.HasValue)
            {
                queryParams.Add("createdDateTo", options.CreatedDateTo);
            }

            if (options.State?.Count > 0)
            {
                foreach (var sessionState in options.State)
                {
                    queryParams.Add("state", sessionState);
                }
            }

            if (options.DueDateFrom.HasValue)
            {
                queryParams.Add("dueDateFrom", options.DueDateFrom);
            }

            if (options.DueDateTo.HasValue)
            {
                queryParams.Add("dueDateTo", options.DueDateTo);
            }

            if (!string.IsNullOrWhiteSpace(options.SessionTitleLike))
            {
                queryParams.Add("sessionTitleLike", options.SessionTitleLike);
            }

            return queryParams;
        }
    }
}