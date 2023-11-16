// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="ViteCommonTagHelper.cs" company="Lukas Tietze">
// Copyright (c) Lukas Tietze. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------------------------------

namespace Budgeteer.Lib.Vite;

using Budgeteer.Lib.Taghelpers;
using Budgeteer.Lib.Vite.TagHelpers;

using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;

/// <summary>
/// Dieser Tag-Helper bindet alle zusätzlichen Skripte ein,
/// die zur Nutzung mit Vite nötig sind.
/// Falls kein Vite-Dev-Server genutzt wird, werden keine Skripte eingebunden.
/// </summary>
[HtmlTargetElement("vite")]
public sealed class ViteCommonTagHelper : ViteTagHelperBase
{
    /// <summary>
    /// Initialisiert eine neue Instanz der <see cref="ViteCommonTagHelper"/> Klasse.
    /// </summary>
    /// <param name="config">Die Vite-Konfiguration.</param>
    /// <param name="uriProvider">Der Dienst zum Erzeugen der URIs.</param>
    public ViteCommonTagHelper(ViteConfig config, IViteUriProvider uriProvider)
        : base(config, uriProvider)
    {
    }

    /// <inheritdoc/>
    public override IHtmlContent Render(IHtmlContent? content = null)
    {
        if (!this.Config)
        {
            return NoContent();
        }

        var uri = this.UriProvider.MakeUri("@vite/client");

        return $"<script src=\"{uri}\" type=\"module\"></script>".ToHTmlContent(escape: false);
    }
}
