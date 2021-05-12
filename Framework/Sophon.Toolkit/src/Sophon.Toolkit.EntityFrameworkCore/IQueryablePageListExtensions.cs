using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sophon.Toolkit.EntityFrameworkCore
{
    public static class IQueryablePageListExtensions
    {
        public static async Task<IPageList<T>> ToPagedListAsync<T>(
            this IQueryable<T> source,
            int pageIndex,
            int pageSize,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var count = await source.CountAsync(cancellationToken).ConfigureAwait(false);
            var items = await source.Skip(pageIndex * pageSize)
                .Take(pageSize).ToListAsync(cancellationToken).ConfigureAwait(false);

            var pagedList = new PagedList<T>()
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                TotalCount = count,
                Items = items,
                TotalPage = (int)Math.Ceiling(count / (double)pageSize)
            };

            return pagedList;
        }
    }
}
