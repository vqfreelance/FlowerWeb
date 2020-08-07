using JavaFlorist.Models.EFCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JavaFlorist.Models.Repositories
{
    public class OccBouquetRepository : GenericRepository<OccBouquet>, IOccBouquetRepository
    {
        public OccBouquetRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }

    }
}
