using JavaFlorist.Models.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JavaFlorist.Models.Repositories
{
    public interface IBouquetRepository : IGenericRepository<Bouquet>
    {
        public List<Bouquet> Search(string keyword);
        public List<Bouquet> Search(decimal min, decimal max);
        public List<Bouquet> Search1(decimal min);
        public List<Bouquet> Search2(decimal max);
    }
}
