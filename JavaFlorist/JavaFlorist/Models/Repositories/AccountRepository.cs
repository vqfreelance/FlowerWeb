using JavaFlorist.Models.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JavaFlorist.Models.Repositories
{
    public class AccountRepository : GenericRepository<Account>, IAccountRepository
    {
        public AccountRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }

        //check username exist
        public bool CheckByUsername(string username)
        {
            if (GetAll().SingleOrDefault(a => a.Username == username) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Account GetByUsername(string username)
        {
            return GetAll().SingleOrDefault(a => a.Username == username);
        }

        public Account GetAccById(int id)
        {
            return GetAll().SingleOrDefault(a => a.Id == id);
        }
    }
}
