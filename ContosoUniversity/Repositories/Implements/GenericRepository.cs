using ContosoUniversity.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContosoUniversity.Repositories.Implements
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
           where TEntity : class
    {
        private readonly SchoolContext _dbContext;

        public GenericRepository(SchoolContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<TEntity>> GetAll()
        {
            return _dbContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
        }

        public async Task Insert(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
        }

        public void Update(int id, TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            _dbContext.Set<TEntity>().Remove(entity);
        }


        public async Task Save()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
