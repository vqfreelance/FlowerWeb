using System;
using System.Collections.Generic;

namespace JavaFlorist.Models
{
    public partial class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
