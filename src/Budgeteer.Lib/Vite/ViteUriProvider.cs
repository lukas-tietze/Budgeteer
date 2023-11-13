// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="ViteUriProvider.cs" company="Lukas Tietze">
// Copyright (c) Lukas Tietze. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------------------------------

namespace Budgeteer.Lib.Vite;

using System;

/// <summary>
/// Die Standardimplementierung von <see cref="IViteUriProvider"/>.
/// </summary>
internal class ViteUriProvider : IViteUriProvider
{
    /// <summary>
    /// Holt die Basis-URI des Vite-Dev-Servers.
    /// </summary>
    private readonly Uri? devServerUri;

    /// <summary>
    /// Die Vite-Konfiguration.
    /// </summary>
    private readonly ViteConfig config;

    /// <summary>
    /// Das ausgelesene Vite-Manifest.
    /// </summary>
    private readonly ViteManifest manifest;

    /// <summary>
    /// Das Objekt mit Informationen zur Hosting-Umgebung.
    /// </summary>
    private readonly IWebHostEnvironment environment;

    /// <summary>
    /// Initialisiert eine neue Instanz der <see cref="ViteUriProvider"/> Klasse.
    /// </summary>
    /// <param name="config">Die Vite-Konfiguration.</param>
    /// <param name="manifest">Das Vite-Manifest.</param>
    /// <param name="environment">Das Objekt mit Informationen zur Hosting-Umgebung.</param>
    public ViteUriProvider(ViteConfig config, ViteManifest manifest, IWebHostEnvironment environment)
    {
        this.config = config;
        this.manifest = manifest;
        this.environment = environment;
        if (this.environment.IsDevelopment() && string.IsNullOrEmpty(this.config.DevServerUri))
        {
            throw new ArgumentException("Dev-Server URI was not provided!");
        }

        if (!string.IsNullOrEmpty(this.config.DevServerUri))
        {
            this.devServerUri = new Uri(this.config.DevServerUri);
        }
    }

    /// <inheritdoc/>
    public string MakeUri(string ressourcePath) => this.environment.IsDevelopment() && this.devServerUri is not null
        ? new Uri(this.devServerUri, ressourcePath).AbsoluteUri
        : this.manifest[ressourcePath].File;
}
