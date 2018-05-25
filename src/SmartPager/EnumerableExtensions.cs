using SmartPager;
using System;
using System.Collections.Generic;
using System.Text;

namespace System.Collections.Generic
{
    public static class EnumerableExtensions
    {
        public static IPagedList<T> ToPagedList<T>(this IEnumerable<T> pageItems, int pageIndex, int pageSize, long totalItemCount)
        {
            return new PagedList<T>(pageItems, pageIndex, pageSize, totalItemCount);
        }
    }
}
