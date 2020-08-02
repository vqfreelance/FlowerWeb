using JavaFlorist.Models.EFCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JavaFlorist.Models.Repositories
{
    public class OccasionRepository : GenericRepository<Occasion>, IOccasionRepository
    {
        private readonly DatabaseContext _dbContext;

        public OccasionRepository(DatabaseContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Occasion> GetById(int id)
        {
            return await _dbContext.Occasion
                .Include(a=>a.Message)
                .Include(a=>a.OccBouquet)
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public List<Occasion> Search(string keyword)
        {
            return GetAllIncludeRelationship().Where(b => b.Name.Contains(keyword)).ToList();
        }

    }
}
