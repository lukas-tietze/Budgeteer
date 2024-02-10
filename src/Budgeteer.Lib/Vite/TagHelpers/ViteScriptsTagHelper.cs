// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="ViteScriptsTagHelper.cs" company="Lukas Tietze">
// Copyright (c) Lukas Tietze. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------------------------------

namespace Budgeteer.Lib.Vite.TagHelpers;

using Budgeteer.Lib.Taghelpers;
using Budgeteer.Lib.Vite;

using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Razor.TagHelpers;

/// <summary>
/// Erzeugt &lt;script&gt;-Tags für alle Skripte, die über einen
/// <see cref="ViteRequireScriptTagHelper"/> angefordert wurden.
/// </summary>
[HtmlTargetElement("vite-scripts")]
public class ViteScriptsTagHelper(IHttpContextAccessor httpContextAccessor, IViteUriProvider uriProvider) : ViteScriptInfraStructureTagHelperBase(httpContextAccessor)
{
    /// <summary>
    /// Der Dienst zum Erzeugen der URIs.
    /// </summary>
    private readonly IViteUriProvider uriProvider = uriProvider;

    /// <inheritdoc/>
    public override IHtmlContent Render(IHtmlContent? content = null)
    {
        var collection = new HtmlContentCollection();

        foreach (var script in this.RequiredScripts)
        {
            collection.Add($"<script src=\"{this.uriProvider.MakeUri(script)}\" type=\"module\"></script>".ToHTmlContent(escape: false));
        }

        return collection.Add($"<script src=\"{this.uriProvider.MakeUri("@vite/client")}\" type=\"module\"></script>".ToHTmlContent(escape: false));
    }
}
