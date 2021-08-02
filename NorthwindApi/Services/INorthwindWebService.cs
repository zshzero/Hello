using System.Threading;
using System.Threading.Tasks;
using NorthwindApi.Models;

namespace NorthwindApi.Services
{
    public interface INorthwindWebService
    {
        Task<Customers> GetCustomersAsync(CancellationToken token);   
    }
}
