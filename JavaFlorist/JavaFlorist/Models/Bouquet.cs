using JavaFlorist.Models.EFCore;
using System;
using System.Collections.Generic;

namespace JavaFlorist.Models
{
    public partial class Bouquet:IEntity
    {
        public Bouquet()
        {
            OccBouquet = new HashSet<OccBouquet>();
            OrderDetail = new HashSet<OrderDetail>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public string Photo { get; set; }
        public bool? Status { get; set; }

        public virtual ICollection<OccBouquet> OccBouquet { get; set; }
        public virtual ICollection<OrderDetail> OrderDetail { get; set; }
    }
}
