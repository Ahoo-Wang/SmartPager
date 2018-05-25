using System;
using System.Collections.Generic;
using System.Text;

namespace SmartPager
{
    public class Constants
    {
        public const String ITEM_INDEX_KEY = "index";
        public const String ITEM_URL_KEY = "url";
        public const String PAGE_TEXT_KEY = "text";
        public const String DEFAULT_TAG_NAME = "ul";

        public const String DEFAULT_ITEM_TEMPLATE = "<li><a href=\"$url\">$index</a></li>";
        public const String DEFAULT_CURRENT_ITEM_TEMPLATE = "<li class=\"active\"><a href=\"$url\">$index</a></li>";
        public const String DEFAULT_TEXT_ITEM_TEMPLATE = "<li><a href=\"$url\">$text</a></li>";
        public const int PADDING_PAGE_NUM = 4;
    }
}
