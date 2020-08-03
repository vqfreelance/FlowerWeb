using JavaFlorist.Models.EFCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JavaFlorist.Models.Repositories
{
    public class AccountRepository : GenericRepository<Account>, IAccountRepository
    {
        private readonly DatabaseContext _dbContext;
        public AccountRepository(DatabaseContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
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
            return GetAllIncludeRelationship().SingleOrDefault(a => a.Username == username);
        }

        public Account GetAccById(int id)
        {
            return GetAll().SingleOrDefault(a => a.Id == id);
        }

        public async Task<Account> GetById2(int id)
        {
            return await _dbContext.Set<Account>()
                .Include(a => a.Order)
                .FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
