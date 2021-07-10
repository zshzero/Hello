using System.Collections.Generic;
using YoloShop.Data;
using YoloShop.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace YoloShop.Controllers
{
    [Route("api/[Controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IYoloShopRepository repository;
        private readonly ILogger<ProductsController> logger;

        public ProductsController(IYoloShopRepository repository, ILogger<ProductsController> logger)
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