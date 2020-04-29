using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Purposes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Purposes.TagHelpers
{
    public class PurposeTagHelper : TagHelper
    {
        public Purpose Item { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.TagMode = TagMode.StartTagAndEndTag;

            output.Content.SetHtmlContent($"<h4>{Item.Name}</h4>");
            output.Content.AppendHtml($"<h5>{Item.Description}</h5>");
            if (Item.Importance == Importance.Important)
            {
                output.Content.AppendHtml($"<h6 style=\"color:red;\">{Item.Importance.ToString()}</h6>");
            }
            else if (Item.Importance == Importance.Unimportant)
            {
                output.Content.AppendHtml($"<h6 style=\"color:green;\">{Item.Importance.ToString()}</h6>");
            }
            else
            {
                output.Content.AppendHtml($"<h6>{Item.Importance.ToString()}</h6>");
            }
            
            if (Item.Due.HasValue)
            {
                output.Content.AppendHtml($"<h6>Due Date: {Item.Due.Value.Date.ToString("dd/MM/yyyy")}</h6>");
            }

            if (Item.IsCompleted)
            {
                output.Content.AppendHtml($"<i>Completed</i><br>");
            }
        }
    }
}
