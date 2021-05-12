using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sophon.Toolkit.EntityFrameworkCore
{
    public interface IRepository<TEntity> where TEntity : class
    {
        #region Find
        Task<IPageList<TEntity>> GetPagedListAsync(Expression<Func<TEntity, bool>> predicate = null,
                                        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
                                        int pageIndex = 0,
                                        int pageSize = 10,
                                        bool noTracking = true,
                                        CancellationToken cancellationToken = default(CancellationToken),
                                        bool ignoreQueryFilters = false);

        ValueTask<TEntity> FindAsync(params object[] keys);
        #endregion

        #region Insert
        TEntity Insert(TEntity entity);
        void Insert(params TEntity[] entities);
        void Insert(IEnumerable<TEntity> entities);
        ValueTask<EntityEntry<TEntity>> InsertAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken));
        Task InsertAsync(params TEntity[] entities);
        Task InsertAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default(CancellationToken));
        #endregion

    }
}
