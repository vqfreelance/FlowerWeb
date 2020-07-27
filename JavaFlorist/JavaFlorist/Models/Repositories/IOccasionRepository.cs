using JavaFlorist.Models.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JavaFlorist.Models.Repositories
{
    public interface IOccasionRepository : IGenericRepository<Occasion>
    {
        public Task<Occasion> GetById(int id);
    }


}
