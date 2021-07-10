using System;
using System.ComponentModel.DataAnnotations;

namespace NorthwindApi.Models
{
    public class Order 
    {
        [Key]
        public int order_id { get; set; }
        public String customer_id { get; set; }
        public int employee_id { get; set; }
        public DateTime order_date { get; set; }
        public DateTime required_date { get; set; }
        public DateTime? shipped_date { get; set; }
        public int ship_via { get; set; }
        public float freight { get; set; }
        public String ship_name { get; set; }
        public String ship_address { get; set; }
        public String ship_city { get; set; }
        public String ship_region { get; set; }
        public String ship_postal_code { get; set; }
        public String ship_country { get; set; }
    }
}    