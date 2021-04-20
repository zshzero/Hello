using System.ComponentModel.DataAnnotations;
using Hello.Data.Entities;

namespace Hello.ViewModel
{
    public class OrderItemViewModel
    {
        public int Id { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public decimal UnitPrice { get; set; }
    }
}