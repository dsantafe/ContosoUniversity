using ContosoUniversity.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContosoUniversity.Services.Implements
{
    public class GenericService<TEntity> : IGenericService<TEntity>
        where TEntity : class
    {
        private IGenericRepository<TEntity> _genericRepository;

        public GenericService(IGenericRepository<TEntity> _genericRepository)
        {
            this._genericRepository = _genericRepository;
        }

        public async Task Delete(int id)
        {
            try
            {
                await _genericRepository.Delete(id);

                await _genericRepository.Save();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<TEntity> GetAll(int pageIndex, int pageSize)
        {
            return _genericRepository.GetAll();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _genericRepository.GetById(id);
        }

        public async Task Create(TEntity entity)
        {
            try
            {
                await _genericRepository.Insert(entity);

                await _genericRepository.Save();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task Update(int id, TEntity entity)
        {
            try
            {
                _genericRepository.Update(id, entity);

                await _genericRepository.Save();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message); throw;
            }

        }
    }
}
