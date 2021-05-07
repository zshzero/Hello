using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Hello.Data;
using Hello.Data.Entities;
using Hello.ViewModel;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Hello.Controllers
{
    [Route("api/[Controller]")]
    [Authorize(AuthenticationSchemes=JwtBearerDefaults.AuthenticationScheme)]
    public class OrdersController : ControllerBase
    {
        private readonly IHelloRepository repository;
        private readonly ILogger logger;
        private readonly IMapper mapper;
        private readonly UserManager<StoreUser> userManager;

        public OrdersController(IHelloRepository repository,
                                ILogger<OrdersController> logger,
                                IMapper mapper,
                                UserManager<StoreUser> userManager)
        {
            this.repository = repository;
            this.logger = logger;
            this.mapper = mapper;
            this.userManager = userManager;
        }

        [HttpGet]
        public IActionResult Get(bool includeItems = true)
        {
            try
            {
                var username = User.Identity.Name;

                var result = repository.GetAllOrdersByUser(username, includeItems);
                return Ok(mapper.Map<IEnumerable<OrderViewModel>>(result)); // Source is infered as param type 
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

                if (order != null) return Ok(mapper.Map<Order, OrderViewModel>(order));
                else return NotFound();
            }
            catch (System.Exception ex)
            {
                logger.LogError($"Failed to get Orders: {ex}");
                return BadRequest("Failed to get Orders");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]OrderViewModel model)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    var newOrder = mapper.Map<Order>(model);

                    if(newOrder.OrderDate == DateTime.MinValue)
                    {
                        newOrder.OrderDate = DateTime.Now;
                    }

                    newOrder.User = await userManager.FindByNameAsync(User.Identity.Name);

                    repository.AddEntity(newOrder);
                    if(repository.SaveAll())
                    {   
                        return Created($"/api/orders/{newOrder.Id}",mapper.Map<OrderViewModel>(newOrder));
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