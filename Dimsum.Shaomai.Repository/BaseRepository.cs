using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Dimsum.Shaomai.DomainEntity;
using Dimsum.Shaomai.Infrastructure;
using Dimsum.Shaomai.IRepository;

namespace Dimsum.Shaomai.Repository
{
    public class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey> where TEntity : class, IBaseEntity
    {
        private readonly DomainContext _domainContext;

        public BaseRepository(DomainContext domainContext)
        {
            _domainContext = domainContext;
        }

        public virtual TEntity Add(TEntity entity)
        {
            entity.CreatedOn = DateTime.Now;
            entity.IsDeleted = false;
            return _domainContext.Add<TEntity>(entity).Entity;
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            entity.CreatedOn = DateTime.Now;
            entity.IsDeleted = false;
            return (await _domainContext.AddAsync<TEntity>(entity, cancellationToken)).Entity;
        }

        public virtual bool Remove(TEntity entity)
        {
            //_domainContext.Remove<TEntity>(entity);
            //全局软删除
            entity.IsDeleted = true;
            entity.DeletedOn = DateTime.Now;
            Update(entity);
            return true;
        }

        public virtual Task<bool> RemoveAsync(TEntity entity)
        {
            return Task.FromResult(Remove(entity));
        }

        public virtual TEntity Get(TKey id)
        {
            return _domainContext.Find<TEntity>(id);
        }

        public virtual async Task<TEntity> GetAsync(TKey id)
        {
            return await _domainContext.FindAsync<TEntity>(id);
        }

        public virtual TEntity Update(TEntity entity)
        {
            return _domainContext.Update(entity).Entity;
        }

        public virtual Task<TEntity> UpdateAsync(TEntity entity)
        {
            return Task.FromResult(Update(entity));
        }
    }
}
