using JavaFlorist.Models.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JavaFlorist.Models
{
    public class ListOrder
    {
        public Order Order { get; set; }
        public decimal Total { get; set; }
    }
}
