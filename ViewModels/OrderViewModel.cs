using System;
using System.ComponentModel.DataAnnotations;

namespace Hello.ViewModel
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        [Required]
        [MinLength(5)]
        public string OrderNumber { get; set; }
    }
}