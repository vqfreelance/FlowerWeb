using System;
using System.Collections.Generic;

namespace JavaFlorist.Models
{
    public partial class Account
    {
        public Account()
        {
            Order = new HashSet<Order>();
        }

        public int AccountId { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<Order> Order { get; set; }
    }
}
