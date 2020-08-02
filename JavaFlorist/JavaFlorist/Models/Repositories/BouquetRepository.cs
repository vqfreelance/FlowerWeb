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
            return GetAllIncludeRelationship().Where(b => b.Name.Contains(keyword)).ToList();
        }

        public List<Bouquet> Search(decimal min, decimal max)
        {
            return GetAllIncludeRelationship().Where(b => b.Price >= min && b.Price <= max).ToList();
        }

        public List<Bouquet> Search1(decimal min)
        {
            return GetAllIncludeRelationship().Where(b => b.Price >= min).ToList();
        }

        public List<Bouquet> Search2(decimal max)
        {
            return GetAllIncludeRelationship().Where(b => b.Price <= max).ToList();
        }

    }
}
