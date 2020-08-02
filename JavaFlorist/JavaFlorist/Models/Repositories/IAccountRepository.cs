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
        bool CheckByUsername(string username);
        Account GetByUsername(string username);
        Account GetAccById(int id);
        Task<Account> GetById2(int id);
    }

}
