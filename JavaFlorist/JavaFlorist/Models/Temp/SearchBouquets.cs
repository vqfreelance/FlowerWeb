using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JavaFlorist.Models.Temp
{
    public class SearchBouquets
    {
        public List<Bouquet> bouquets { get; set; }
        public string keyword { get; set; }
        public decimal min { get; set; }
        public decimal max { get; set; }

    }
}
