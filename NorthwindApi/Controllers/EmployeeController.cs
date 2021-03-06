using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NorthwindApi.Models;
using System.Threading.Tasks;
using System.Threading;

namespace NorthwindApi.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger logger;
        private readonly IRepository repository;

        public EmployeeController(ILogger<Employee> logger, IRepository repository)
        {
            this.logger = logger;
            this.repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetAllEmployees(CancellationToken token)
        {
            try
            {
                logger.LogInformation($"Begin - Get Details of All Employees");
                var result = await repository.GetAllEmployees(token);
                logger.LogInformation($"End - Get Details of All Employees");
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                logger.LogError($"Failed: {ex}");
                return BadRequest("Failed to get Employees");
            }

        }

        [HttpGet("{EmployeeId:int}")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployeeById(int EmployeeId, CancellationToken token)
        {
            try
            {
                logger.LogInformation($"Begin - Get Details of Employee - {EmployeeId}");
                var result = await repository.GetEmployeeById(EmployeeId, token);
                logger.LogInformation($"End - Get Details of Employee - {EmployeeId}");
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                logger.LogError($"Failed: {ex}");
                return BadRequest($"Failed to get Employee");
            }

        }
    
        [HttpGet("{EmployeeId:int}/order/{OrderId:int}")]
        public ActionResult<IEnumerable<Order>> GetOrdersByEmployeeId(int EmployeeId, int OrderId)
        {
            throw new System.Exception("Middleware up");
            return Ok(repository.GetOrdersByEmployeeId(EmployeeId, OrderId));
        }
    }
}
