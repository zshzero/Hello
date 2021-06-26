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
        public ActionResult<IEnumerable<Employee>> Get()
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
    }
}