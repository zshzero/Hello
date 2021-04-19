using System;
using Hello.Data;
using Hello.Data.Entities;
using Hello.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Hello.Controllers
{
    [Route("api/[Controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IHelloRepository repository;
        private readonly ILogger logger;

        public OrdersController(IHelloRepository repository, ILogger<OrdersController> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(repository.GetAllOrders());
            }
            catch (System.Exception ex)
            {
                logger.LogError($"Failed to get Orders: {ex}");
                return BadRequest("Failed to get Orders");
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id) 
        {
            try
            {
                var order = repository.GetOrderById(id);

                if (order != null) return Ok(order);
                else return NotFound();
            }
            catch (System.Exception ex)
            {
                logger.LogError($"Failed to get Orders: {ex}");
                return BadRequest("Failed to get Orders");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody]OrderViewModel model)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    var newOrder = new Order()
                    {
                        OrderDate = model.OrderDate,
                        OrderNumber = model.OrderNumber,
                        Id = model.OrderId
                    };

                    if(newOrder.OrderDate == DateTime.MinValue)
                    {
                        newOrder.OrderDate = DateTime.Now;
                    }

                    repository.AddEntity(newOrder);
                    if(repository.SaveAll())
                    {
                        var vm = new OrderViewModel()
                        {
                            OrderId = newOrder.Id,
                            OrderDate = newOrder.OrderDate,
                            OrderNumber = newOrder.OrderNumber
                        };
                        
                        return Created($"/api/orders/{vm.OrderId}",vm);
                    }
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (System.Exception ex)
            {
                logger.LogError($"Failed to add order : {ex}");
            }

            return BadRequest("Failed to add order");
        }
    }
}