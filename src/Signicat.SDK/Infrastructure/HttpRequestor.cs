using System;
using System.Collections.Specialized;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Signicat.Infrastructure
{
    internal static class HttpRequestor
    {
        private static readonly HttpClient HttpClient;

        static HttpRequestor()
        {
            HttpClient = SignicatConfiguration.HttpClient ?? new HttpClient();
        }

        public static SignicatResponse Get(string url, string token = null)
        {
            return Send(url, HttpMethod.Get, token);
        }

        public static Task<SignicatResponse> GetAsync(string url, string token = null)
        {
            return SendAsync(url, HttpMethod.Get, token);
        }

        public static SignicatResponse Post(string url, string jsonBody = null, string token = null)
        {
            return Send(url, HttpMethod.Post, token, jsonBody);
        }

        public static Task<SignicatResponse> PostAsync(string url, string jsonBody = null, string token = null)
        {
            return SendAsync(url, HttpMethod.Post, token, jsonBody);
        }

        public static SignicatResponse PostFormData(string url, NameValueCollection formData, string token = null)
        {
            return Send(url, HttpMethod.Post, token, formData: formData);
        }

        public static Task<SignicatResponse> PostFormDataAsync(string url, NameValueCollection formData,
            string token = null)
        {
            return SendAsync(url, HttpMethod.Post, token, formData: formData);
        }

        public static SignicatResponse PostContentFormData(string url, MultipartFormDataContent content,
            string token = null)
        {
            return Send(url, HttpMethod.Post, token, formDataContent: content);
        }

        public static Task<SignicatResponse> PostContentFormDataAsync(string url, MultipartFormDataContent content,
            string token = null)
        {
            return SendAsync(url, HttpMethod.Post, token, formDataContent: content);
        }

        public static SignicatResponse Patch(string url, string jsonBody = null, string token = null)
        {
            return Send(url, new HttpMethod("PATCH"), token, jsonBody);
        }

        public static Task<SignicatResponse> PatchAsync(string url, string jsonBody = null, string token = null)
        {
            return SendAsync(url, new HttpMethod("PATCH"), token, jsonBody);
        }

        public static SignicatResponse Put(string url, string jsonBody = null, string token = null)
        {
            return Send(url, HttpMethod.Put, token, jsonBody);
        }

        public static Task<SignicatResponse> PutAsync(string url, string jsonBody = null, string token = null)
        {
            return SendAsync(url, HttpMethod.Put, token, jsonBody);
        }

        public static SignicatResponse Delete(string url, string token = null)
        {
            return Send(url, HttpMethod.Delete, token);
        }

        public static Task<SignicatResponse> DeleteAsync(string url, string token = null)
        {
            return SendAsync(url, HttpMethod.Delete, token);
        }

        public static Stream GetStream(string url, string token = null)
        {
            var request = GetRequestMessage(url, HttpMethod.Get, token);

            return ExecuteRawRequest(request);
        }

        public static Task<Stream> GetStreamAsync(string url, string token = null)
        {
            var request = GetRequestMessage(url, HttpMethod.Get, token);

            return ExecuteRawRequestAsync(request);
        }

        internal static HttpRequestMessage GetRequestMessage(string url, HttpMethod method, string token = null,
            string jsonBody = null, NameValueCollection formData = null,
            MultipartFormDataContent formDataContent = null)
        {
            var request = BuildRequest(url, method, jsonBody, formData, formDataContent);

            request.Headers.Add("Signicat-SDK", $"dotnet {SignicatConfiguration.SdkVersion}");
            request.Headers.Add("User-Agent", $"Signicat-SDK dotnet {SignicatConfiguration.SdkVersion}");

            if (!string.IsNullOrWhiteSpace(token))
            {
                request.Headers.Add("Authorization", $"Bearer {token}");
            }

            return request;
        }

        private static SignicatResponse Send(string url, HttpMethod method, string token = null, string jsonBody = null,
            NameValueCollection formData = null, MultipartFormDataContent formDataContent = null)
        {
            var request = GetRequestMessage(url, method, token, jsonBody, formData, formDataContent);

            return ExecuteRequest(request);
        }

        private static Task<SignicatResponse> SendAsync(string url, HttpMethod method, string token = null,
            string jsonBody = null, NameValueCollection formData = null,
            MultipartFormDataContent formDataContent = null)
        {
            var request = GetRequestMessage(url, method, token, jsonBody, formData, formDataContent);

            return ExecuteRequestAsync(request);
        }

        private static HttpRequestMessage BuildRequest(string url, HttpMethod method, string jsonBody = null,
            NameValueCollection formData = null, MultipartFormDataContent formDataContent = null)
        {
            var request = new HttpRequestMessage(method, new Uri(url));

            if (method != HttpMethod.Post && method != HttpMethod.Put && method.Method != "PATCH")
                return request;

            var postData = jsonBody;
            var contentType = "application/json";

            if (string.IsNullOrWhiteSpace(jsonBody) && formData != null)
            {
                postData = APIHelper.ToQueryString(formData).Substring(1);
                contentType = "application/x-www-form-urlencoded";
            }

            request.Content = !string.IsNullOrWhiteSpace(postData)
                ? new StringContent(postData, Encoding.UTF8, contentType)
                : null;

            if (request.Content == null && formDataContent != null)
            {
                request.Content = formDataContent;
            }

            return request;
        }

        private static SignicatResponse ExecuteRequest(HttpRequestMessage requestMessage)
        {
            return AsyncHelper.RunSync(() => ExecuteRequestAsync(requestMessage));
        }

        private static async Task<SignicatResponse> ExecuteRequestAsync(HttpRequestMessage requestMessage)
        {
            var response = await HttpClient.SendAsync(requestMessage);
            var content = await response.Content.ReadAsStringAsync();

            var result = BuildResponseData(response, content);

            if (response.IsSuccessStatusCode)
                return result;

            throw BuildException(result, response.StatusCode);
        }

        private static Stream ExecuteRawRequest(HttpRequestMessage requestMessage)
        {
            return AsyncHelper.RunSync(() => ExecuteRawRequestAsync(requestMessage));
        }

        private static async Task<Stream> ExecuteRawRequestAsync(HttpRequestMessage requestMessage)
        {
            var response = await HttpClient.SendAsync(requestMessage);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsStreamAsync();

            var errorContent = await response.Content.ReadAsStringAsync();
            var result = BuildResponseData(response, errorContent);

            throw BuildException(result, response.StatusCode);
        }

        private static SignicatResponse BuildResponseData(HttpResponseMessage response, string responseJson)
        {
            return new SignicatResponse()
            {
               
                ResponseJson = responseJson
            };
        }

        private static SignicatException BuildException(SignicatResponse response, HttpStatusCode statusCode)
        {
            var signicatError = Mapper.MapFromJson<SignicatError>(response.ResponseJson);

            return new SignicatException(
                statusCode,
                signicatError,
                response,
                signicatError?.Message ?? signicatError?.OAuthError);
        }
    }
}