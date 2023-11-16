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
public class ViteScriptsTagHelper : ViteScriptInfraStructureTagHelperBase
{
    /// <summary>
    /// >Die Vite-Konfiguration.
    /// </summary>
    private readonly ViteConfig config;

    /// <summary>
    /// Der Dienst zum Erzeugen der URIs.
    /// </summary>
    private readonly IViteUriProvider uriProvider;

    /// <summary>
    /// Initialisiert eine neue Instanz der <see cref="ViteScriptsTagHelper"/> Klasse.
    /// </summary>
    /// <param name="httpContextAccessor">Das Objekt zum Zugriff auf den aktuellen <see cref="HttpContext"/>.</param>
    /// <param name="config">Die Vite-Konfiguration.</param>
    /// <param name="uriProvider">Der Dienst zum Erzeugen der URIs.</param>
    public ViteScriptsTagHelper(IHttpContextAccessor httpContextAccessor, ViteConfig config, IViteUriProvider uriProvider)
        : base(httpContextAccessor)
    {
        this.config = config;
        this.uriProvider = uriProvider;
    }

    /// <inheritdoc/>
    public override IHtmlContent Render(IHtmlContent? content = null)
    {
        var collection = new HtmlContentCollection();

        foreach (var script in this.RequiredScripts)
        {
            var tagHelper = new ViteScriptTagHelper(this.config, this.uriProvider) { Source = script };

            collection.Add(tagHelper.Render());
        }

        var commonTagHelper = new ViteCommonTagHelper(this.config, this.uriProvider);

        return collection.Add(commonTagHelper.Render());
    }
}
