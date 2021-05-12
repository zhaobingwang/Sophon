using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sophon.Toolkit.EntityFrameworkCore
{
    public interface IPageList<T>
    {
        int PageIndex { get; }
        int PageSize { get; }
        int TotalCount { get; }
        int TotalPage { get; }
        IList<T> Items { get; }
        bool HasPreviousPage { get; }
        bool HasNextPage { get; }
    }
}
