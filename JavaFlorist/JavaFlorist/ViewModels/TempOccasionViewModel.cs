using JavaFlorist.Models;
using JavaFlorist.Models.Temp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JavaFlorist.ViewModels
{
    public class TempOccasionViewModel
    {
        public List<TempOccasion> TempOccasions { get; set; }
        public Bouquet Bouquet { get; set; }
    }
}
