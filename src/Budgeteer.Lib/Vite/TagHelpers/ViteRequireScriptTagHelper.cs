// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="ViteRequireScriptTagHelper.cs" company="Lukas Tietze">
// Copyright (c) Lukas Tietze. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------------------------------

namespace Budgeteer.Lib.Vite.TagHelpers;

using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Razor.TagHelpers;

/// <summary>
/// Über diesen Taghelper kann ein Skript für Vite im &lt;head&gt;-Element
/// der Seite angefordert werden, wodurch eventuell benötigte bzw. hilfreiche
/// Preload-Header erzeugt werden können.
///
/// Zum Laden des eigentlichen Skripts ist dann ein &lt;vite-scripts&gt;-Tag erforderlich.
/// </summary>
[HtmlTargetElement("vite-require-script", Attributes = "src")]
public class ViteRequireScriptTagHelper : ViteScriptInfraStructureTagHelperBase
{
    /// <summary>
    /// Initialisiert eine neue Instanz der <see cref="ViteRequireScriptTagHelper"/> Klasse.
    /// </summary>
    /// <param name="httpContextAccessor">Das Objekt zum Zugriff auf den aktuellen <see cref="HttpContext"/>.</param>
    public ViteRequireScriptTagHelper(IHttpContextAccessor httpContextAccessor)
        : base(httpContextAccessor)
    {
    }

    /// <summary>
    /// Holt oder setzt die URL des angeforderten Skripts.
    /// </summary>
    [HtmlAttributeName("src")]
    public string Source { get; set; } = string.Empty;

    /// <inheritdoc/>
    public override IHtmlContent Render(IHtmlContent? content = null)
    {
        this.RequiredScripts.Add(this.Source);

        return NoContent();
    }
}
