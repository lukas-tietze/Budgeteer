// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="ViteTagHelperBase.cs" company="Lukas Tietze">
// Copyright (c) Lukas Tietze. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------------------------------

namespace Budgeteer.Lib.Vite.TagHelpers;

using Budgeteer.Lib.Taghelpers;
using Budgeteer.Lib.Vite;

/// <summary>
/// Stellt die Basisklasse für Tag-Helper dar die, die Skripte oder Style über den Vite-dev-Server einbinden.
/// </summary>
public abstract class ViteTagHelperBase : RenderedSyncTagHelperBase
{
    /// <summary>
    /// Initialisiert eine neue Instanz der <see cref="ViteTagHelperBase"/> Klasse.
    /// </summary>
    /// <param name="config">Die Vite-Konfiguration.</param>
    /// <param name="uriProvider">Der Dienst zum Erzeugen der URIs.</param>
    public ViteTagHelperBase(ViteConfig config, IViteUriProvider uriProvider)
    {
        this.Config = config;
        this.UriProvider = uriProvider;
    }

    /// <summary>
    /// Holt die Vite-Konfiguration.
    /// </summary>
    protected ViteConfig Config
    {
        get;
    }

    /// <summary>
    /// Holt den Dienst zum Erzeugen der URIs.
    /// </summary>
    protected IViteUriProvider UriProvider
    {
        get;
    }
}
