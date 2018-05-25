using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartPager
{
    public class PagerTagHelper : TagHelper
    {
        public IPagedList PagedList { get; set; }
        public PagerOptions Options { get; set; }

        public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagMode = TagMode.StartTagAndEndTag;
            output.TagName = Options.TagName;
           
            if (!String.IsNullOrEmpty(Options.Id))
            {
                output.Attributes.Add("id", Options.Id);
            }
            if (!String.IsNullOrEmpty(Options.CssClass))
            {
                output.Attributes.Add("class", Options.CssClass);
            }

            return Task.CompletedTask;
        }
    }
}
