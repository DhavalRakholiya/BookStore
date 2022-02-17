using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBookStore.Helpers
{
    [HtmlTargetElement("Big")]
    [HtmlTargetElement(Attributes = "Big")]
    public class BigTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "h3";
            output.Attributes.RemoveAll("Big");
            output.PreContent.SetHtmlContent("<p>Pre Content</p>");
            output.PostContent.SetHtmlContent("<p>Post Content</p>");
            output.Attributes.SetAttribute("class", "h3");
        }
    }
}
