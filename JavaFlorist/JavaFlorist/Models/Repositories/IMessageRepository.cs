using JavaFlorist.Models.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JavaFlorist.Models.Repositories
{
    public interface IMessageRepository : IGenericRepository<Message>
    {
        public List<Message> GetAllMessbyOccId(int id);
    }


}
