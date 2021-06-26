using System;
using System.ComponentModel.DataAnnotations;

namespace NorthwindApi.Models
{
    public class Employee
    {
        [Key]
        public int employee_id { get; set; }
        public String first_name { get; set; }
        public String last_name { get; set; }
        public String title { get; set; }
    }
}