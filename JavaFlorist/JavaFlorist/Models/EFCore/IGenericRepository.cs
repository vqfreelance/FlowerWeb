using System.Linq;
using System.Threading.Tasks;

namespace JavaFlorist.Models.EFCore
{
    public interface IGenericRepository<TEntity>
        where TEntity : class
    {
        IQueryable<TEntity> GetAll();

        IQueryable<TEntity> GetAllIncludeRelationship();

        Task<TEntity> GetById(int id);

        Task<TEntity> GetByIdIncludeRelationship(int id);

        Task Create(TEntity entity);

        Task Update(int id, TEntity entity);

        Task Delete(int id);
    }
}