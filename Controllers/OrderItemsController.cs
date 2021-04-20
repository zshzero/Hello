using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Hello.Data;
using Hello.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Hello.Controllers
{
    [Route("api/orders/{orderid}/items")]
    public class OrderItemsController : ControllerBase
    {
        private readonly IHelloRepository repository;
        private readonly ILogger logger;
        private readonly IMapper mapper;

        public OrderItemsController(IHelloRepository repository,
                                ILogger<OrdersController> logger,
                                IMapper mapper)
        {
            this.repository = repository;
            this.logger = logger;
            this.mapper = mapper;
        }
        [HttpGet]
        public IActionResult Get(int orderId)
        {
            var order = repository.GetOrderById(orderId);
            if(order != null) return Ok(mapper.Map<IEnumerable<OrderItemViewModel>>(order.Items));
            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int orderId, int id)
        {
            var order = repository.GetOrderById(orderId);
            if(order != null) 
            {
                var item = order.Items.Where(i => i.Id == id).FirstOrDefault();
                if (item != null)
                {
                    return Ok(mapper.Map<OrderItemViewModel>(item));
                }
            }
            return NotFound();
        }
    }
}