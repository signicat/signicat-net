using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Signicat.Infrastructure;

namespace Signicat
{
    public abstract class SignicatBaseService
    {
        private readonly string _clientId;
        private readonly string _clientSecret;
        private OAuthToken _oAuthToken;
        private readonly string _organizationId = null;

        protected SignicatBaseService()
        {
        }

        protected SignicatBaseService(string organizationId)
        {
            _organizationId = organizationId ?? throw new ArgumentNullException(nameof(organizationId));
        }

        protected SignicatBaseService(string clientId, string clientSecret)
        {
            _clientId = clientId ?? throw new ArgumentNullException(nameof(clientId));
            _clientSecret = clientSecret ?? throw new ArgumentNullException(nameof(clientSecret));
        }

        protected SignicatBaseService(string clientId, string clientSecret, string organizationId)
        {
            _clientId = clientId ?? throw new ArgumentNullException(nameof(clientId));
            _clientSecret = clientSecret ?? throw new ArgumentNullException(nameof(clientSecret));
            _organizationId = organizationId ?? throw new ArgumentNullException(nameof(organizationId));
        }


        protected T Get<T>(string url)
        {
            return Mapper.MapFromJson<T>(HttpRequestor.Get(url, GetToken(), _organizationId));
        }

        protected async Task<T> GetAsync<T>(string url)
        {
            return Mapper.MapFromJson<T>(await HttpRequestor.GetAsync(url, GetToken(), _organizationId));
        }

        protected string Get(string url)
        {
            return HttpRequestor.Get(url, GetToken(), _organizationId)?.ResponseJson;
        }

        protected async Task<string> GetAsync(string url)
        {
            return (await HttpRequestor.GetAsync(url, GetToken(), _organizationId))?.ResponseJson;
        }

        protected Stream GetFile(string url)
        {
            return HttpRequestor.GetStream(url, GetToken(), _organizationId);
        }

        protected async Task<Stream> GetFileAsync(string url)
        {
            return await HttpRequestor.GetStreamAsync(url, GetToken(), _organizationId);
        }

        protected T Post<T>(string url, object requestObject = null)
        {
            return Mapper.MapFromJson<T>(
                HttpRequestor.Post(url, Mapper.MapToJson(requestObject), GetToken(), _organizationId));
        }

        protected async Task<T> PostAsync<T>(string url, object requestObject = null)
        {
            return Mapper.MapFromJson<T>(
                await HttpRequestor.PostAsync(url, Mapper.MapToJson(requestObject), GetToken(), _organizationId));
        }

        protected void Post(string url, object requestObject = null)
        {
            HttpRequestor.Post(url, Mapper.MapToJson(requestObject), GetToken(), _organizationId);
        }

        protected async Task PostAsync(string url, object requestObject = null)
        {
            await HttpRequestor.PostAsync(url, Mapper.MapToJson(requestObject), GetToken(), _organizationId);
        }

        protected void PostFormContentData(string url, MultipartFormDataContent requestObject = null)
        {
            HttpRequestor.PostContentFormData(url, requestObject, GetToken(), _organizationId);
        }

        protected async Task PostFormContentDataAsync(string url, MultipartFormDataContent requestObject = null)
        {
            await HttpRequestor.PostContentFormDataAsync(url, requestObject, GetToken(), _organizationId);
        }

        protected T PostFormContentData<T>(string url, MultipartFormDataContent requestObject = null)
        {
            return Mapper.MapFromJson<T>(
                HttpRequestor.PostContentFormData(url, requestObject, GetToken(), _organizationId));
        }

        protected async Task<T> PostFormContentDataAsync<T>(string url, MultipartFormDataContent requestObject = null)
        {
            return Mapper.MapFromJson<T>(
                await HttpRequestor.PostContentFormDataAsync(url, requestObject, GetToken(), _organizationId));
        }

        protected T Patch<T>(string url, object requestObject = null)
        {
            return Mapper.MapFromJson<T>(
                HttpRequestor.Patch(url, Mapper.MapToJson(requestObject), GetToken(), _organizationId));
        }

        protected async Task<T> PatchAsync<T>(string url, object requestObject = null)
        {
            return Mapper.MapFromJson<T>(
                await HttpRequestor.PatchAsync(url, Mapper.MapToJson(requestObject), GetToken(), _organizationId));
        }

        protected void PatchWithoutResponse(string url, object requestObject = null)
        {
            HttpRequestor.Patch(url, Mapper.MapToJson(requestObject), GetToken(), _organizationId);
        }

        protected async Task PatchWithoutResponseAsync(string url, object requestObject = null)
        {
            await HttpRequestor.PatchAsync(url, Mapper.MapToJson(requestObject), GetToken(), _organizationId);
        }

        protected T Put<T>(string url, object requestObject = null)
        {
            return Mapper.MapFromJson<T>(
                HttpRequestor.Put(url, Mapper.MapToJson(requestObject), GetToken(), _organizationId));
        }

        protected async Task<T> PutAsync<T>(string url, object requestObject = null)
        {
            return Mapper.MapFromJson<T>(
                await HttpRequestor.PutAsync(url, Mapper.MapToJson(requestObject), GetToken(), _organizationId));
        }

        protected void Put(string url, object requestObject = null)
        {
            HttpRequestor.Put(url, Mapper.MapToJson(requestObject), GetToken(), _organizationId);
        }

        protected async Task PutAsync(string url, object requestObject = null)
        {
            await HttpRequestor.PutAsync(url, Mapper.MapToJson(requestObject), GetToken(), _organizationId);
        }

        protected T PostFile<T>(string url, byte[] filedata, string fileName)
        {
            return Mapper.MapFromJson<T>(
                HttpRequestor.PostFile<T>(url, fileName, filedata, GetToken()));
        }

        protected async Task<T> PostFileAsync<T>(string url, byte[] filedata, string fileName)
        {
            return Mapper.MapFromJson<T>(
                await HttpRequestor.PostFileAsync<T>(url, fileName, filedata, GetToken()));
        }


        protected void Delete(string url)
        {
            HttpRequestor.Delete(url, GetToken(), _organizationId);
        }

        protected async Task DeleteAsync(string url)
        {
            await HttpRequestor.DeleteAsync(url, GetToken(), _organizationId);
        }

        private string GetToken()
        {
            if (_oAuthToken?.Expiry > DateTime.UtcNow)
            {
                return _oAuthToken.AccessToken;
            }

            _oAuthToken = _clientId == null
                ? AuthManager.Authorize()
                : AuthManager.Authorize(_clientId, _clientSecret);

            return _oAuthToken.AccessToken;
        }
    }
}