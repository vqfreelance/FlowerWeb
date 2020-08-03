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
        Bouquet GetBouquetById(int id);
        List<Bouquet> GetBouquetByStatus();
        List<Bouquet> GetRandomBouquets(int number);
        List<Bouquet> SearchByKeyword(string keyword);
    }
}
