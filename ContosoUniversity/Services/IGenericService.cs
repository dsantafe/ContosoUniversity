using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContosoUniversity.Services
{
    public interface IGenericService<TEntity>
        where TEntity : class
    {
        List<TEntity> GetAll(int pageIndex, int pageSize);

        Task<TEntity> GetById(int id);

        Task Create(TEntity entity);

        Task Update(int id, TEntity entity);

        Task Delete(int id);
    }
}
