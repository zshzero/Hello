using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NorthwindApi.Models;
using NorthwindApi;

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
        public ActionResult<IEnumerable<Order>> GetAllOrdersByEmployeeId(int EmployeeId)
        {
             try
            {
                return Ok(repository.GetAllOrdersByEmployeeId(EmployeeId));
            }
            catch (System.Exception ex)
            {
                logger.LogError($"Failed: {ex}");
                return BadRequest($"Failed to get Orders by Employee");
            }
            
        }
    }
}