using JavaFlorist.Models.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JavaFlorist.Models.Repositories
{
    public interface IBouquetRepository : IGenericRepository<Bouquet>
    {
        List<Bouquet> Search(string keyword);
        List<Bouquet> Search(decimal min, decimal max);
        List<Bouquet> Search1(decimal min);
        List<Bouquet> Search2(decimal max);
        Bouquet GetBouquetById(int id);
        List<Bouquet> GetBouquetByStatus();
        List<Bouquet> GetRandomBouquets(int number);
        List<Bouquet> SearchByKeyword(string keyword);

        //load pagination
        //IEnumerable<Bouquet> getProductAll();
        public int totalProduct(List<Bouquet> bouquets);
        int numberPage(int totalProduct, int limit);
        IEnumerable<Bouquet> paginationProduct(int start, int limit, List<Bouquet> bouquets);

    }
}
