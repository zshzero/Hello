using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace YoloShop.ViewModel
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        [Required]
        [MinLength(5)]
        public string OrderNumber { get; set; }
        public ICollection<OrderItemViewModel> Items { get; set; }
    }
}