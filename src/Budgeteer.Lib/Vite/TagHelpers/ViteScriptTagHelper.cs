// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="ViteScriptTagHelper.cs" company="Lukas Tietze">
// Copyright (c) Lukas Tietze. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------------------------------

namespace Budgeteer.Lib.Vite.TagHelpers;

using Budgeteer.Lib.Taghelpers;
using Budgeteer.Lib.Vite;

using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;

/// <summary>
/// Dieser Tag-Helper hilft, Skripte vom Vite-dev-Server abzurufen.
/// </summary>
[HtmlTargetElement("vite-script", Attributes = "src")]
public sealed class ViteScriptTagHelper : ViteTagHelperBase
{
    /// <summary>
    /// Initialisiert eine neue Instanz der <see cref="ViteScriptTagHelper"/> Klasse.
    /// </summary>
    /// <param name="config">Die Vite-Konfiguration.</param>
    /// <param name="uriProvider">Der Dienst zum Erzeugen der URIs.</param>
    public ViteScriptTagHelper(ViteConfig config, IViteUriProvider uriProvider)
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

        return $"<script src=\"{uri}\" type=\"module\"></script>".ToHTmlContent(escape: false);
    }
}
