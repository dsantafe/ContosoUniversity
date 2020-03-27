using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContosoUniversity.Services
{
    public interface IGenericService<TEntity>
        where TEntity : class
    {
        Task<List<TEntity>> GetAll();

        Task<TEntity> GetById(int id);

        Task Create(TEntity entity);

        Task Update(int id, TEntity entity);

        Task Delete(int id);
    }
}
