// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="ApiPropsTagHelper.cs" company="Lukas Tietze">
// Copyright (c) Lukas Tietze. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------------------------------

namespace Budgeteer.App.TagHelpers;

using Budgeteer.App.Config;

using Microsoft.AspNetCore.Razor.TagHelpers;

/// <summary>
/// 
/// </summary>
[HtmlTargetElement("api-env")]
public class ApiEnvironmentTagHelper(AppConfig config) : TagHelper
{
    /// <summary>
    /// Die Andwendungskonfiguration.
    /// </summary>
    private readonly AppConfig config = config;

    /// <inheritdoc/>
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagMode = TagMode.StartTagAndEndTag;
        output.TagName = "div";

        output.Attributes.Add("class", "hidden");
        output.Attributes.Add("id", "ApiEnvironment");
        output.Attributes.Add("data-api-url", this.config.Paths.BaseHref);
    }
}
