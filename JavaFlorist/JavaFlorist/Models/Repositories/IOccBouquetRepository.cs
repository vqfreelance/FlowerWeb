using JavaFlorist.Models.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JavaFlorist.Models.Repositories
{
    public interface IOccBouquetRepository : IGenericRepository<OccBouquet>
    {
        public Task<OccBouquet> GetById(int id);
    }


}
