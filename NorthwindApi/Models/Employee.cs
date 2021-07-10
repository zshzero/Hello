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
        public String title_of_courtesy { get; set; }
        public DateTime birth_date { get; set; }
        public DateTime hire_date { get; set; }
        public String address { get; set; }
        public String city { get; set; }
        public String region { get; set; }
        public String postal_code { get; set; }
        public String country { get; set; }
        public String home_phone { get; set; }
        public String extension { get; set; }
        public String notes { get; set; }
        public int? reports_to { get; set; }
    }
}