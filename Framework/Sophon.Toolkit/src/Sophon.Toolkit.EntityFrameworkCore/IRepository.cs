using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sophon.Toolkit.EntityFrameworkCore
{
    public interface IRepository<TEntity> where TEntity : class
    {
        ValueTask<EntityEntry<TEntity>> InsertAsync(TEntity entity);
        Task InserManytAsync(params TEntity[] entities);
        ValueTask<TEntity> FindAsync(params object[] keys);
    }
}
