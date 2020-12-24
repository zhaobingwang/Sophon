using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sophon.Toolkit.EntityFrameworkCore
{
    /// <summary>
    /// 工作单元接口
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// 获取<typeparamref name="TEntity"/>的存储库
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <returns>继承自<see cref="IRepository{TEntity}"/>的实例</returns>
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;

        /// <summary>
        /// 异步的将此工作单元中的所有更改保存到数据库
        /// </summary>
        /// <returns>异步保存操作结果：<see cref="Task{TResult}"/>，Task的结果为写入数据库的的实体的数量。</returns>
        Task<int> SaveChangesAsync();
    }

    /// <summary>
    /// 泛型工作单元接口
    /// </summary>
    /// <typeparam name="TContext"></typeparam>
    public interface IUnitOfWork<TContext> : IUnitOfWork where TContext : DbContext
    {
        /// <summary>
        /// 获取数据库上下文
        /// </summary>
        /// <returns><typeparamref name="TContext"/>实例</returns>
        TContext DbContext { get; }

        ///// <summary>
        ///// 将此上下文中所做的所有更改保存到数据库中
        ///// </summary>
        ///// <param name="unitOfWorks"></param>
        ///// <returns>表示异步保存操作： <see cref="Task{TResult}"/>，Task结果为写入数据库的实体的数量。</returns>
        //Task<int> SaveChangesAsync(params IUnitOfWork[] unitOfWorks);
    }
}
