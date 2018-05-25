using System;
using System.Collections.Generic;
using System.Text;

namespace SmartPager
{
    public class PagerOptions
    {
        public string Id { get; set; }
        public string TagName { get; set; } = Constants.DEFAULT_TAG_NAME;
        public string CssClass { get; set; }
        public string PageIndexParameterKey { get; set; } = "PageIndex";
        /// <summary>
        /// 首页
        /// </summary>
        public string FirstText { get; set; } = "首页";
        /// <summary>
        /// 尾页
        /// </summary>
        public string LastText { get; set; } = "尾页";
        /// <summary>
        /// 分页项模板
        /// Params:{index,url}
        /// <li><a href=\"$url\">$index<a></li>
        /// </summary>
        public string ItemTemplate { get; set; } = Constants.DEFAULT_ITEM_TEMPLATE;
        public string PreText { get; set; } = "<";
        public string NextText { get; set; } = ">";
        public string CurrentTemplate { get; set; } = Constants.DEFAULT_CURRENT_ITEM_TEMPLATE;
        public string TextTemplate { get; set; } = Constants.DEFAULT_TEXT_ITEM_TEMPLATE;
        public string RouteName { get; set; }
        public bool NoMorePageHide { get; set; } = true;
        public int PaddingPageNum { get; set; } = Constants.PADDING_PAGE_NUM;
    }
}
