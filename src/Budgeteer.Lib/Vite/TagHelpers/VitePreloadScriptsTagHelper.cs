// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="VitePreloadScriptsTagHelper.cs" company="Lukas Tietze">
// Copyright (c) Lukas Tietze. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------------------------------

namespace Budgeteer.Lib.Vite.TagHelpers;

using System.Linq;

using Budgeteer.Lib.Taghelpers;
using Budgeteer.Lib.Vite;

using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Razor.TagHelpers;

/// <summary>
/// Über diesen Taghelper werden verschiedene Tags zum Anfordern von Stilen
/// und zum Vorladen von Skripten in das &gt;head&lt;-Element eingefügt.
/// </summary>
[HtmlTargetElement("vite-head")]
public class VitePreloadScriptsTagHelper : ViteScriptInfraStructureTagHelperBase
{
    /// <summary>
    /// Der Dienst zum Erzeugen der URIs.
    /// </summary>
    private readonly IViteUriProvider uriProvider;

    /// <summary>
    /// Der Dienst zum Abrufen von Abhängikeiten von Skripten.
    /// </summary>
    private readonly IViteDependencyProvider dependencyProvider;

    /// <summary>
    /// Initialisiert eine neue Instanz der <see cref="VitePreloadScriptsTagHelper"/> Klasse.
    /// </summary>
    /// <param name="httpContextAccessor">Das Objekt zum Zugriff auf den aktuellen <see cref="HttpContext"/>.</param>
    /// <param name="uriProvider">Der Dienst zum Erzeugen der URIs.</param>
    /// <param name="dependencyProvider">Der Dienst zum Abrufen von Abhängikeiten von Skripten.</param>
    public VitePreloadScriptsTagHelper(IHttpContextAccessor httpContextAccessor, IViteUriProvider uriProvider, IViteDependencyProvider dependencyProvider)
        : base(httpContextAccessor)
    {
        this.uriProvider = uriProvider;
        this.dependencyProvider = dependencyProvider;
    }

    /// <inheritdoc/>
    public override IHtmlContent Render(IHtmlContent? content = null)
    {
        var collection = new HtmlContentCollection();

        var deps = this.RequiredScripts.SelectMany(s => this.dependencyProvider.ListDependencies(s).Append((DependencyType.Script, s)));

        foreach (var (type, path) in deps)
        {
            collection.Add((type switch
            {
                DependencyType.Script => $"<link href=\"{this.uriProvider.MakeUri(path)}\" rel=\"preload\" as=\"script\">",
                DependencyType.Style => $"<link href=\"{path}\" rel=\"stylesheet\" type=\"text/css\">",
                DependencyType.Asset => $"<link href=\"{path}\" rel=\"preload\" as=\"image\">",
                _ => string.Empty,
            }).ToHTmlContent(escape: false));
        }

        return collection;
    }
}
