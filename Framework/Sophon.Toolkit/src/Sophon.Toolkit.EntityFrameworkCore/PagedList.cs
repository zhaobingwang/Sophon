using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sophon.Toolkit.EntityFrameworkCore
{
    public class PagedList<T> : IPageList<T>
    {
        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public int TotalCount { get; set; }

        public int TotalPage { get; set; }

        public IList<T> Items { get; set; }

        public bool HasPreviousPage => PageIndex > 1;

        public bool HasNextPage => PageIndex < TotalPage;

        internal PagedList()
        {
            Items = new T[0];
        }
    }
}
