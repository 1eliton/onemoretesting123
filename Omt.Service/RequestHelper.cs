using Omt.Service;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Tango.Types;

namespace Omt.Services
{
    public class RequestHelper : IRequestHelper
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RequestHelper(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<Option<HttpResponseMessage>> GetAsync(string requestUri)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, requestUri);
                using (var client = _httpClientFactory.CreateClient())
                {
                    return await client.SendAsync(request);
                }

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
