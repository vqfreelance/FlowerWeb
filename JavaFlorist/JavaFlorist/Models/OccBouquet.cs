using JavaFlorist.Models.EFCore;
using System;
using System.Collections.Generic;

namespace JavaFlorist.Models
{
    public partial class OccBouquet:IEntity
    {
        public int Id { get; set; }
        public int? OccasionId { get; set; }
        public int? BouquetId { get; set; }

        public virtual Bouquet Bouquet { get; set; }
        public virtual Occasion Occasion { get; set; }
    }
}
