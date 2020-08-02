using JavaFlorist.Models.EFCore;
using System;
using System.Collections.Generic;

namespace JavaFlorist.Models
{
    public partial class Order: IEntity
    {
        public Order()
        {
            OrderDetail = new HashSet<OrderDetail>();
        }

        public int Id { get; set; }
        public int AccountId { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
        public string ReceivingTime { get; set; }
        public DateTime CreateDate { get; set; }

        public virtual Account Account { get; set; }
        public virtual ICollection<OrderDetail> OrderDetail { get; set; }
    }
}
