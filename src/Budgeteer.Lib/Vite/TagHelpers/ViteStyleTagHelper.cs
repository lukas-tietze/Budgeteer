// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="ViteStyleTagHelper.cs" company="Lukas Tietze">
// Copyright (c) Lukas Tietze. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------------------------------

namespace Budgeteer.Lib.Vite.TagHelpers;

using Budgeteer.Lib.Taghelpers;
using Budgeteer.Lib.Vite;

using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;

/// <summary>
/// Dieser Tag-Helper hilft, Style vom Vite-dev-Server abzurufen.
/// </summary>
[HtmlTargetElement("vite-style", Attributes = "src")]
public sealed class ViteStyleTagHelper : ViteTagHelperBase
{
    /// <summary>
    /// Initialisiert eine neue Instanz der <see cref="ViteStyleTagHelper"/> Klasse.
    /// </summary>
    /// <param name="config">Die Vite-Konfiguration.</param>
    /// <param name="uriProvider">Der Dienst zum Erzeugen der URIs.</param>
    public ViteStyleTagHelper(ViteConfig config, IViteUriProvider uriProvider)
        : base(config, uriProvider)
    {
        this.Source = string.Empty;
    }

    /// <summary>
    /// Holt oder setzt den Pfad zur gesuchten Datei.
    /// </summary>
    [HtmlAttributeName("src")]
    public string Source
    {
        get;
        set;
    }

    /// <inheritdoc/>
    public override IHtmlContent Render(IHtmlContent? content = null)
    {
        var uri = this.UriProvider.MakeUri(this.Source);

        return $"<link rel=\"stylesheet\" type=\"text/css\" href=\"{uri}\" />".ToHTmlContent(escape: false);
    }
}
