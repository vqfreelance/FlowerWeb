using JavaFlorist.Models.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JavaFlorist.Models.Repositories
{
    public class BouquetRepository : GenericRepository<Bouquet>, IBouquetRepository
    {
        private List<Bouquet> bouquets = new List<Bouquet>();

        public BouquetRepository(DatabaseContext dbContext) : base(dbContext)
        {
            bouquets = GetAll().ToList();
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

        //load pagination
        public IEnumerable<Bouquet> getProductAll()
        {
            return bouquets;
        }
        public int totalProduct()
        {
            return bouquets.Count;
        }
        public int numberPage(int totalProduct, int limit)
        {
            float numberpage = totalProduct / limit;
            return (int)Math.Ceiling(numberpage);
        }
        public IEnumerable<Bouquet> paginationProduct(int start, int limit)
        {
            var data = (from s in bouquets select s);
            var dataProduct = data.OrderByDescending(x => x.Id).Skip(start).Take(limit);
            return dataProduct.ToList();
        }

    }
}
