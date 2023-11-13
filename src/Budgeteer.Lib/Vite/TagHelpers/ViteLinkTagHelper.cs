// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="ViteLinkTagHelper.cs" company="Lukas Tietze">
// Copyright (c) Lukas Tietze. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------------------------------

namespace Budgeteer.Lib.Vite.TagHelpers;

using Budgeteer.Lib.Taghelpers;
using Budgeteer.Lib.Vite;

using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

/// <summary>
/// Dieser Tag-Helper erzeugt einen &lt;link&gt;-Tag mit einer
/// von Vite bereitgestellten Href.
/// </summary>
[HtmlTargetElement("vite-link", Attributes = "href")]
public sealed class ViteLinkTagHelper : ViteTagHelperBase
{
    /// <summary>
    /// Initialisiert eine neue Instanz der <see cref="ViteLinkTagHelper"/> Klasse.
    /// </summary>
    /// <param name="config">Die Vite-Konfiguration.</param>
    /// <param name="uriProvider">Der Dienst zum Erzeugen der URIs.</param>
    public ViteLinkTagHelper(ViteConfig config, IViteUriProvider uriProvider)
        : base(config, uriProvider)
    {
        this.Source = string.Empty;
    }

    /// <summary>
    /// Holt oder setzt den Pfad zur gesuchten Datei.
    /// </summary>
    [HtmlAttributeName("href")]
    public string Source
    {
        get;
        set;
    }

    /// <inheritdoc/>
    public override IHtmlContent Render(IHtmlContent? content = null)
    {
        var uri = this.UriProvider.MakeUri(this.Source);

        return new FluentTagBuilder("link", TagRenderMode.SelfClosing)
            .SetAttributes(this.Attributes)
            .SetAttribute("href", uri, true);
    }
}
