using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;
using NorthwindApi.Models;

namespace NorthwindApi.Services
{
    class NorthwindWebService : INorthwindWebService
    {
        public IHttpClientFactory HttpClientFactory { get; }
        
        public NorthwindWebService(IHttpClientFactory httpClientFactory)
        {
            this.HttpClientFactory = httpClientFactory;
        }
        
        public async Task<Customers> GetCustomersAsync(CancellationToken token)
        {
            var httpclient = HttpClientFactory.CreateClient("NorthwindWebService");
            
            var result = await httpclient.GetFromJsonAsync<Customers>("customers.json", token);
            return result;
        }
    }
}
