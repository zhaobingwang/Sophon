using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sophon.Toolkit.EntityFrameworkCore
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task InsertAsync(params TEntity[] entities);
        ValueTask<TEntity> FindAsync(params object[] keys);
    }
}
