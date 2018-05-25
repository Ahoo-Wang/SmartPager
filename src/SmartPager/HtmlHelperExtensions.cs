using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartPager
{
    public static class HtmlHelperExtensions
    {
        public static IHtmlContent Pager(this IHtmlHelper htmlHelper, IPagedList pagedList, PagerOptions options)
        {
            TagBuilder pagerTagBuilder = new TagBuilder(options.TagName);
            if (!String.IsNullOrEmpty(options.Id))
            {
                pagerTagBuilder.MergeAttribute("id", options.Id);
            }
            pagerTagBuilder.AddCssClass(options.CssClass);
            bool notShowPager = options.NoMorePageHide && (pagedList.MaxPageIndex == 1);
            if (notShowPager)
            {
                return pagerTagBuilder;
            }
            UrlHelperFactory urlHelperFactory = new UrlHelperFactory();
            var urlHelper = urlHelperFactory.GetUrlHelper(htmlHelper.ViewContext);
            #region Init Query Dic
            var ignoreCaseComparer = StringComparer.Create(System.Threading.Thread.CurrentThread.CurrentCulture, true);
            var dicQuery = new Dictionary<string, object>(ignoreCaseComparer);
            foreach (var item in htmlHelper.ViewContext.HttpContext.Request.Query)
            {
                dicQuery.Add(item.Key, item.Value);
            }
            if (dicQuery.ContainsKey(options.PageIndexParameterKey))
            {
                dicQuery[options.PageIndexParameterKey] = 1;
            }
            else
            {
                dicQuery.Add(options.PageIndexParameterKey, 1);
            }
            #endregion
            #region FirstPage
            if (pagedList.CurrentPageIndex > 1)
            {
                var nextPageUrl = urlHelper.Link(options.RouteName, dicQuery);
                AddPageItem(pagerTagBuilder, options.TextTemplate, nextPageUrl, options.FirstText);
            }
            #endregion
            #region PrePage
            int prePageIndex = pagedList.CurrentPageIndex - 1;
            if (prePageIndex > 1)
            {
                dicQuery[options.PageIndexParameterKey] = prePageIndex;
                var prePageUrl = urlHelper.Link(options.RouteName, dicQuery);
                AddPageItem(pagerTagBuilder, options.TextTemplate, prePageUrl, options.PreText);
            }
            #endregion
            #region NumericalPage
            
            int startPageIndex = pagedList.CurrentPageIndex - options.PaddingPageNum;
            if (startPageIndex < 1) { startPageIndex = 1; }
            int endPageIndex = pagedList.CurrentPageIndex + options.PaddingPageNum;
            if (endPageIndex > pagedList.MaxPageIndex)
            {
                endPageIndex = pagedList.MaxPageIndex;
            }
            for (int pageIndex = startPageIndex; pageIndex <= endPageIndex; pageIndex++)
            {
                string template = options.ItemTemplate;
                if (pageIndex == pagedList.CurrentPageIndex)
                {
                    template = options.CurrentTemplate;
                }
                dicQuery[options.PageIndexParameterKey] = pageIndex;
                string itemPageUrl = urlHelper.Link(options.RouteName, dicQuery);
                AddPageItem(pagerTagBuilder, template, itemPageUrl, pageIndex);
            }
            #endregion
            #region NextPage
            int nextPageIndex = pagedList.CurrentPageIndex + 1;
            if (nextPageIndex < pagedList.MaxPageIndex)
            {
                dicQuery[options.PageIndexParameterKey] = nextPageIndex;
                var nextPageUrl = urlHelper.Link(options.RouteName, dicQuery);
                AddPageItem(pagerTagBuilder, options.TextTemplate, nextPageUrl, options.NextText);
            }
            #endregion
            #region LastPage
            if (pagedList.CurrentPageIndex < pagedList.MaxPageIndex)
            {
                dicQuery[options.PageIndexParameterKey] = pagedList.MaxPageIndex;
                var lastPageUrl = urlHelper.Link(options.RouteName, dicQuery);
                AddPageItem(pagerTagBuilder, options.TextTemplate, lastPageUrl, options.LastText);
            }
            #endregion
            return pagerTagBuilder;
        }

        private static void AddPageItem(TagBuilder pagerTagBuilder, string template, string itemPageUrl, int itemPageIndex)
        {
            string pageItemHtmlStr = template.Replace($"${Constants.ITEM_INDEX_KEY}", itemPageIndex.ToString());
            pageItemHtmlStr = pageItemHtmlStr.Replace($"${Constants.ITEM_URL_KEY}", itemPageUrl);
            pagerTagBuilder.InnerHtml.AppendHtml(pageItemHtmlStr);
        }
        private static void AddPageItem(TagBuilder pagerTagBuilder, string template, string itemPageUrl, string itemPageText)
        {
            string pageItemHtmlStr = template.Replace($"${Constants.PAGE_TEXT_KEY}", itemPageText);
            pageItemHtmlStr = pageItemHtmlStr.Replace($"${Constants.ITEM_URL_KEY}", itemPageUrl);
            pagerTagBuilder.InnerHtml.AppendHtml(pageItemHtmlStr);
        }
    }
}
