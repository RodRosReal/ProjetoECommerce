using ECommerce.Domain.ValueObjects;
using System.Collections.Generic;

namespace ECommerce.Domain.Core
{
    public interface IRepository<TEntity>
    {
        TEntity Get(params object[] keys);

        TEntity Get(BaseSpecification<TEntity> spec);

        List<TEntity> Query(BaseSpecification<TEntity> spec);

        List<TEntity> Query(BaseSpecification<TEntity> spec, string orderBy, SortDirection direction);

        List<TEntity> QueryAll(int limitCount = RepositoryConstants.DefaultQueryLimitCount);

        PagedResult<TEntity> QueryPaged(PagedOptions pagedOptions);

        PagedResult<TEntity> QueryPaged(PagedOptions pagedOptions, BaseSpecification<TEntity> spec);

        bool Exists();

        bool Exists(BaseSpecification<TEntity> spec);

        long Count();

        long Count(BaseSpecification<TEntity> spec);

        void Insert(TEntity entity);

        void Insert(IEnumerable<TEntity> entityList);

        void Update(TEntity entity);

        void Update(IEnumerable<TEntity> entityList);

        void Delete(TEntity entity);

        void Delete(IEnumerable<TEntity> entityList);
    }
}
