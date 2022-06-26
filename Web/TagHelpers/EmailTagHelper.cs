using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetLayeredArchitectureWithDapper.Web.TagHelpers
{
    public class EmailTagHelper : TagHelper
    {
        public string Adress { get; set; }
        public string Content { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            output.Attributes.SetAttribute("href", $"mailto:{Adress}");
            output.Content.SetContent(Content);
            base.Process(context, output);
        }
    }
}
