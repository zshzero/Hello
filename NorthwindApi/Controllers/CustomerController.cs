using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NorthwindApi.Models;
using NorthwindApi.Services;

namespace NorthwindApi.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger logger;
        private readonly INorthwindWebService NorthwindWebService;

        public CustomerController(ILogger<Customers> logger, INorthwindWebService NorthwindWebService)
        {
            this.logger = logger;
            this.NorthwindWebService = NorthwindWebService;
        }

        [HttpGet]
        public async Task<ActionResult<Task<Customers>>> GetAllCustomers(CancellationToken token)
        {
            logger.LogInformation($"Begin - Get Details of All Customers");
            var result = await NorthwindWebService.GetCustomersAsync(token);
            logger.LogInformation($"End - Get Details of All Customers");
            return Ok(result);
        }
    }
}
