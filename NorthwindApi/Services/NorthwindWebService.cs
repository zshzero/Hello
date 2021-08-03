using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;
using NorthwindApi.Models;

namespace NorthwindApi.Services
{
    class NorthwindWebService : INorthwindWebService
    {
        public HttpClient HttpClient { get; }
        
        public NorthwindWebService(HttpClient httpClient)
        {
            this.HttpClient = httpClient;
        }
        
        public async Task<Customers> GetCustomersAsync(CancellationToken token)
        {            
            var result = await HttpClient.GetFromJsonAsync<Customers>("customers.json", token);
            return result;
        }
    }
}
