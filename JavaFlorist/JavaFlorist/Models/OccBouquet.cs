using System;
using System.Collections.Generic;

namespace JavaFlorist.Models
{
    public partial class OccBouquet
    {
        public int? OccBouquetId { get; set; }
        public int? OccasionId { get; set; }
        public int? BouquetId { get; set; }

        public virtual Bouquet Bouquet { get; set; }
        public virtual Occcasion Occasion { get; set; }
    }
}
