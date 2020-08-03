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
        private readonly DatabaseContext _dbContext;

        public OccBouquetRepository(DatabaseContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OccBouquet> GetById(int id)
        {
            return await _dbContext.OccBouquet
                .Include(a=>a.Occasion)
                .Include(a=>a.Bouquet)
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
        }

    }
}
