using JavaFlorist.Models.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JavaFlorist.Models.Repositories
{
    public class BouquetItemRepository : GenericRepository<BouquetItem>, IBouquetItemRepository
    {
        public BouquetItemRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }

       
    }
}
