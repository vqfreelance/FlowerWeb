﻿using System;
using System.Collections.Generic;

namespace JavaFlorist.Models
{
    public partial class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int? OrderId { get; set; }
        public int? BouquetId { get; set; }
        public int? Quantity { get; set; }

        public virtual Bouquet Bouquet { get; set; }
        public virtual Order Order { get; set; }
    }
}
