using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace igi.TagHelpers
{
    [HtmlTargetElement(tag: "img", Attributes = "img-action, img-controller")]
    public class ImageTagHelper : TagHelper
    {
        public string ImageAction { get; set; }
        public string ImageController { get; set; }
        LinkGenerator _linkGenerator;

        public ImageTagHelper(LinkGenerator link)
        {
            _linkGenerator = link;
        }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var uri = _linkGenerator.GetPathByAction(ImageAction, ImageController);
            output.Attributes.Add("src", uri);
        }
    }
}
