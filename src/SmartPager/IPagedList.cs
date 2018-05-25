using System;
using System.Collections;
using System.Collections.Generic;

namespace SmartPager
{
    public interface IPagedList : IEnumerable
    {
        int CurrentPageIndex { get; }
        int PageSize { get; }
        long TotalItemCount { get; }
        int MaxPageIndex { get; }

    }
    public interface IPagedList<T> : IEnumerable<T>, IPagedList { }
}
