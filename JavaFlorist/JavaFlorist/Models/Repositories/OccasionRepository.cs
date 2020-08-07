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
        // show bouquet as id
        public List<Occasion> GetNumberOcc(int number)
        {
            return GetAll().Take(number).ToList();
        }

        public List<Bouquet> GetBouquetsByOcc(int id)
        {
            return GetAll().Where(o => o.Id == id)
                .SelectMany(o => o.OccBouquet)
                .Select(ob => ob.Bouquet).ToList();
        }
        public List<Occasion> Search(string keyword)
        {
            return GetAllIncludeRelationship().Where(b => b.Name.Contains(keyword)).ToList();
        }
    }
}
