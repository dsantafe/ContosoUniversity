using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContosoUniversity.Repositories
{
    public interface IGenericRepository<TEntity>
         where TEntity : class
    {
        List<TEntity> GetAll();

        Task<TEntity> GetById(int id);

        Task Insert(TEntity entity);

        void Update(int id, TEntity entity);

        Task Delete(int id);

        Task Save();
    }
}
