using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartPager
{
    public class PagedList<T> : List<T>, IPagedList<T>
    {
        public PagedList(IEnumerable<T> currentPageItems, int pageIndex, int pageSize, long totalItemCount)
        {
            TotalItemCount = totalItemCount;
            CurrentPageIndex = pageIndex;
            PageSize = pageSize;
            AddRange(currentPageItems);
        }

        public int CurrentPageIndex { get; }

        public int PageSize { get; }

        public long TotalItemCount { get; }

        public int MaxPageIndex { get { return (int)Math.Ceiling(TotalItemCount / (double)PageSize); } }
    }
}
