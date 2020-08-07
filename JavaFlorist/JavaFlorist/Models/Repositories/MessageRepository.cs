using JavaFlorist.Models.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JavaFlorist.Models.Repositories
{
    public class MessageRepository : GenericRepository<Message>, IMessageRepository
    {
        public MessageRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }
        public List<Message> GetAllMessbyOccId (int id)
        {
            return GetAll().Where(m => m.OccasionId == id).ToList();
        }
        public List<Message> Search(string keyword)
        {
            return GetAllIncludeRelationship().Where(m => m.MeContent.Contains(keyword)).ToList();
        }
    }
}
