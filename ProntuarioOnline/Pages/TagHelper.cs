using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace ProntuarioOnline.TagHelpers;

[HtmlTargetElement("label", Attributes = ForAttributeName)]
public class RequiredLabelTagHelper : TagHelper
{
  private const string ForAttributeName = "asp-for";

  [HtmlAttributeName(ForAttributeName)]
  public ModelExpression For { get; set; }

  public override void Process(TagHelperContext context, TagHelperOutput output)
  {
    var metadata = For.Metadata;
    var isRequired = metadata.ValidatorMetadata
        .OfType<RequiredAttribute>()
        .Any();

    if (isRequired)
    {
      var labelText = output.Content.IsModified ?
          output.Content.GetContent() : metadata.DisplayName ?? For.Name;

      output.Content.SetHtmlContent($"{labelText} <span style='color:red'>*</span>");
    }
  }
}