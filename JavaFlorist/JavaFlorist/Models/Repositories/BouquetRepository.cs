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

        // show bouquet by id
        public Bouquet GetBouquetById(int id)
        {
            return GetAll().SingleOrDefault(b => b.Id == id);
        }
        public List<Bouquet> GetBouquetByStatus()
        {
            return GetAll().Where(b => b.Status == true).ToList();
        }

        public List<Bouquet> GetRandomBouquets(int number)
        {
            return GetAll().OrderBy(b => Guid.NewGuid()).Take(number).ToList();
        }

        public List<Bouquet> SearchByKeyword(string keyword)
        {
            return GetAll().Where(b => b.Name.Contains(keyword)).ToList();
        }
    }
}
