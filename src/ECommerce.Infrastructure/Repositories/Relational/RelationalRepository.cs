using ECommerce.Domain.Core;
using ECommerce.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ECommerce.Infrastructure.Repositories.Relational
{
    public class RelationalRepository<TEntity>
        where TEntity : class
    {
        private readonly DbContext dbContext;
        private readonly DbSet<TEntity> dbSet;

        public RelationalRepository()
        {
            var context = DataContextFactory.GetDataContext();
            this.dbContext = context ?? throw new ArgumentNullException(nameof(context));
            this.dbSet = this.dbContext.Set<TEntity>();
        }

        public TEntity Get(params object[] keys)
        {
            if (keys == null)
                throw new ArgumentNullException(nameof(keys));

            return this.dbSet.Find(keys);
        }

        public TEntity Get(BaseSpecification<TEntity> spec)
        {
            if (spec == null)
                throw new ArgumentNullException(nameof(spec));

            return this.QueryAsTracking().FirstOrDefault(spec.Expression);
        }

        public List<TEntity> Query(BaseSpecification<TEntity> spec)
        {
            if (spec == null)
                throw new ArgumentNullException(nameof(spec));

            return this.Query()
                .Where(spec.Expression)
                .ToList();
        }

        public List<TEntity> QueryAll(int limitCount = RepositoryConstants.DefaultQueryLimitCount)
        {
            return this.Query()
                .Take(limitCount)
                .ToList();
        }

        public PagedResult<TEntity> QueryPaged(PagedOptions pagedOptions)
        {
            if (pagedOptions == null)
                throw new ArgumentNullException(nameof(pagedOptions));

            var query = this.Query();

            if (!string.IsNullOrEmpty(pagedOptions.OrderBy))
                query = query.OrderBy(pagedOptions.OrderBy, pagedOptions.Direction);

            return query.ToPaged(pagedOptions.PageNumber, pagedOptions.PageSize, pagedOptions.IncludeTotalCount);
        }

        public PagedResult<TEntity> QueryPaged(PagedOptions pagedOptions, BaseSpecification<TEntity> spec)
        {
            if (pagedOptions == null)
                throw new ArgumentNullException(nameof(pagedOptions));

            if (spec == null)
                throw new ArgumentNullException(nameof(spec));

            var query = this.Query().Where(spec.Expression);

            if (!string.IsNullOrEmpty(pagedOptions.OrderBy))
                query = query.OrderBy(pagedOptions.OrderBy, pagedOptions.Direction);

            return query.ToPaged(pagedOptions.PageNumber, pagedOptions.PageSize, pagedOptions.IncludeTotalCount);
        }

        public bool Exists()
        {
            return this.Query().Any();
        }

        public bool Exists(BaseSpecification<TEntity> spec)
        {
            if (spec == null)
                throw new ArgumentNullException(nameof(spec));

            return this.Query().Any(spec.Expression);
        }

        public long Count()
        {
            return this.Query().LongCount();
        }

        public long Count(BaseSpecification<TEntity> spec)
        {
            if (spec == null)
                throw new ArgumentNullException(nameof(spec));

            return this.Query().LongCount(spec.Expression);
        }

        public void Insert(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            this.dbContext.Entry(entity).State = EntityState.Added;
        }

        public void Insert(IEnumerable<TEntity> entityList)
        {
            if (entityList == null)
                throw new ArgumentNullException(nameof(entityList));

            foreach (var item in entityList)
                this.Insert(item);
        }

        public void Update(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            this.dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Update(IEnumerable<TEntity> entityList)
        {
            if (entityList == null)
                throw new ArgumentNullException(nameof(entityList));

            foreach (var item in entityList)
                this.Update(item);
        }

        public void Delete(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            this.dbContext.Entry(entity).State = EntityState.Deleted;
        }

        public void Delete(IEnumerable<TEntity> entityList)
        {
            if (entityList == null)
                throw new ArgumentNullException(nameof(entityList));

            foreach (var item in entityList)
                this.Delete(item);
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected IQueryable<TEntity> Query()
        {
            return this.dbSet.AsNoTracking();
        }

        protected IQueryable<TEntity> QueryAsTracking()
        {
            return this.dbSet;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing && this.dbContext != null)
                this.dbContext.Dispose();
        }
    }
}
