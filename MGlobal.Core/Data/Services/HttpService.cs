using System;
using System.Net.Http;
using System.Threading.Tasks;
using MGlobal.Core.Domain.Contracts;

namespace MGlobal.Core.Data.Services
{
    public class HttpService : IHttpService
    {
        public HttpRequestMessage CreateHttpRequestMessage(string requestUri, HttpMethod method, HttpContent content)
        {
            return new HttpRequestMessage
            {
                RequestUri = new Uri(requestUri),
                Method = method,
                Content = content
            };
        }

        public async Task<HttpResponseMessage> ExecuteRequest(HttpRequestMessage request)
        {
            using (HttpClient client = new HttpClient())
            {
                return await client.SendAsync(request);
            }
        }
    }
}
