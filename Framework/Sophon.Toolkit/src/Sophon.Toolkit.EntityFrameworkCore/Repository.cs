using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sophon.Toolkit.EntityFrameworkCore
{
    /// <summary>
    /// 默认的通用存储库，实现了<see cref="IRepository{TEntity}"/>接口。
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _dbContext;
        protected readonly DbSet<TEntity> _dbSet;

        /// <summary>
        /// 初始化<see cref="Repository{TEntity}"/>类的一个新实例。
        /// </summary>
        /// <param name="dbContext">数据库上下文</param>
        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }

        /// <summary>
        /// 查找具有给定主键值的实体。如果找到，则附加到上下文并返回。
        /// 如果没有找到实体，则返回null。
        /// </summary>
        /// <param name="keyValues">待查找的主键值</param>
        /// <returns></returns>
        public virtual ValueTask<TEntity> FindAsync(params object[] keyValues)
        {
            return _dbSet.FindAsync(keyValues);
        }

        public virtual Task InsertAsync(params TEntity[] entities)
        {
            return _dbSet.AddRangeAsync(entities);
        }
    }
}
