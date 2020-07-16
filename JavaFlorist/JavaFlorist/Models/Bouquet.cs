using System;
using System.Collections.Generic;

namespace JavaFlorist.Models
{
    public partial class Bouquet
    {
        public Bouquet()
        {
            OrderDetail = new HashSet<OrderDetail>();
        }

        public int BouquetId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public string Photo { get; set; }

        public virtual ICollection<OrderDetail> OrderDetail { get; set; }
    }
}
