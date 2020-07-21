using JavaFlorist.Models.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JavaFlorist.Models.Repositories
{
    public class BouquetRepository : GenericRepository<Bouquet>, IBouquetRepository
    {
        public BouquetRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }

        public List<Bouquet> Search(string keyword)
        {
            return GetAll().Where(b => b.Name.Contains(keyword)).ToList();
        }

        public List<Bouquet> Search(decimal min, decimal max)
        {
            return GetAll().Where(b => b.Price >= min && b.Price <= max).ToList();
        }
    }
}
