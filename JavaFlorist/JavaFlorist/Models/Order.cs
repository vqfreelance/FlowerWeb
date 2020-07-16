using System;
using System.Collections.Generic;

namespace JavaFlorist.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderDetail = new HashSet<OrderDetail>();
        }

        public int OrderId { get; set; }
        public int? AccountId { get; set; }
        public int? SenderId { get; set; }
        public int? ReceiverId { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
        public DateTime? ReceivingTime { get; set; }

        public virtual Account Account { get; set; }
        public virtual ICollection<OrderDetail> OrderDetail { get; set; }
    }
}
