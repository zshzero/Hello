using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NorthwindApi.Models;

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
        public ActionResult<IEnumerable<Employee>> GetAllEmployees()
        {
             try
            {
                return Ok(repository.GetAllEmployees());
            }
            catch (System.Exception ex)
            {
                logger.LogError($"Failed: {ex}");
                return BadRequest("Failed to get Employees");
            }
            
        }

        [HttpGet("{EmployeeId:int}")] 
        public ActionResult<IEnumerable<Employee>> GetEmployeeById(int EmployeeId)
        {
             try
            {
                return Ok(repository.GetEmployeeById(EmployeeId));
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
             try
            {
                return Ok(repository.GetOrdersByEmployeeId(EmployeeId, OrderId));
            }
            catch (System.Exception ex)
            {
                logger.LogError($"Failed: {ex}");
                return BadRequest($"Failed to get Order by Employee");
            }
            
        }
    }
}