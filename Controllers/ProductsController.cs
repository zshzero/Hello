using System.Collections.Generic;
using Hello.Data;
using Hello.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Hello.Controllers
{
    [Route("api/[Controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IHelloRepository repository;
        private readonly ILogger<ProductsController> logger;

        public ProductsController(IHelloRepository repository, ILogger<ProductsController> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public ActionResult<IEnumerable<Product>> Get()
        {
            try
            {
                return Ok(repository.GetAllProducts());
            }
            catch (System.Exception ex)
            {
                logger.LogError($"Failed:{ex}");
                return BadRequest("Failed to get products");
            }
            
        }
    }
}