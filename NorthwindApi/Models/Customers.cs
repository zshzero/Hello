using System;
using System.Collections.Generic;

namespace NorthwindApi.Models
{
    public class Customers
    {
        public IEnumerable<CustomerDetails> results { get; set; }
    }
    
    public class CustomerDetails
    {
        public string id { get; set; }
        public string companyName { get; set; }
        public string contactName { get; set; }
        public string contactTitle { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string postalCode { get; set; }
        public string country { get; set; }
        public string phone { get; set; }
        public string fax { get; set; }
    }
}
