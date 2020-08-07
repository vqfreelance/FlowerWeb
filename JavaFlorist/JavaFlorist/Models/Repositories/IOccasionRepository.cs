using JavaFlorist.Models.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JavaFlorist.Models.Repositories
{
    public interface IOccasionRepository : IGenericRepository<Occasion>
    {
        List<Occasion> GetNumberOcc(int number);
        List<Bouquet> GetBouquetsByOcc(int id);

        List<Occasion> Search(string keyword);
    }


}
