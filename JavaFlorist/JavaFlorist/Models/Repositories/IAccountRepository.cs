using JavaFlorist.Models.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JavaFlorist.Models.Repositories
{
    public interface IAccountRepository : IGenericRepository<Account>
    {
        //check username exist
        public bool CheckByUsername(string username);
        public Account GetByUsername(string username);
        public Account GetAccById(int id);
    }

}
