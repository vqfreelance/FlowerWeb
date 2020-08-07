using JavaFlorist.Models.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JavaFlorist.Models.Repositories
{
    public interface IMessageRepository : IGenericRepository<Message>
    {
        List<Message> GetAllMessbyOccId(int id);
        List<Message> Search(string keyword);
    }


}
