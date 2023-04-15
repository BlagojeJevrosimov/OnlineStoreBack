using Common.Contracts;
using Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ContractImplementations
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : BaseEntity, new()
    {
        private readonly IBaseRepository<TEntity> _baseRepository;

        public BaseService(IBaseRepository<TEntity> repository)
        {
            _baseRepository = repository;
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            TEntity tempEntity = await _baseRepository.GetByIdAsync(id);

            if (tempEntity is null)
                throw new BusinessException("Entity doesn't exist", System.Net.HttpStatusCode.BadRequest);

            return tempEntity;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _baseRepository.GetAllAsync();
        }

        public async Task<IEnumerable<TEntity>> GetFilteredAsync(Func<TEntity, bool> filter)
        {
            return await _baseRepository.GetFilteredAsync(filter);
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            return await _baseRepository.AddAsync(entity);
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            TEntity tempEntity = await _baseRepository.GetByIdAsync(entity.Id);

            if (tempEntity is null)
                throw new BusinessException("Entity doesn't exist", System.Net.HttpStatusCode.BadRequest);

            return await _baseRepository.UpdateAsync(entity);
        }

        public async Task<bool> DeleteAsync(TEntity entity)
        {
            TEntity tempEntity = await _baseRepository.GetByIdAsync(entity.Id);

            if (tempEntity is null)
                throw new BusinessException("Entity doesn't exist", System.Net.HttpStatusCode.BadRequest);

            return await _baseRepository.DeleteAsync(entity);
            
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            TEntity tempEntity = await _baseRepository.GetByIdAsync(id);

            if (tempEntity is null)
                throw new BusinessException("Entity doesn't exist", System.Net.HttpStatusCode.BadRequest);

            return await _baseRepository.DeleteByIdAsync(id);
        }
    }
}
