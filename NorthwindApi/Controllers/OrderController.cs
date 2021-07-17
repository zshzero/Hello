using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NorthwindApi.Models;
using NorthwindApi;
using System.Threading.Tasks;
using System.Threading;

namespace Northwind.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger logger;
        private readonly IRepository repository;

        public OrderController(ILogger<Order> logger, IRepository repository)
        {
            this.logger = logger;
            this.repository = repository;
        }
        
        [HttpGet("employee/{EmployeeId:int}")] 
        public async Task<ActionResult<IEnumerable<Order>>> GetAllOrdersByEmployeeId(int EmployeeId)
        {
             try
            {
                var result = await repository.GetAllOrdersByEmployeeId(EmployeeId);
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                logger.LogError($"Failed: {ex}");
                return BadRequest($"Failed to get Orders by Employee");
            }
            
        }

        [HttpGet("{OrderId:int}")] 
        public async Task<ActionResult<Order>> GetOrderById(int OrderId, CancellationToken token)
        {
             try
            {
                var result = await repository.GetOrderById(OrderId, token);
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                logger.LogError($"Failed: {ex}");
                return BadRequest($"Failed to get Order");
            }
            
        }
    }
}