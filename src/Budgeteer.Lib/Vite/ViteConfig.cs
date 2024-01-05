// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="ViteConfig.cs" company="Lukas Tietze">
// Copyright (c) Lukas Tietze. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------------------------------

namespace Budgeteer.Lib.Vite;

/// <summary>
/// Stellt die Konfiguration für Vite dar.
/// </summary>
public class ViteConfig
{
    /// <summary>
    /// Holt oder setzt die URI des Vite-Dev-Servers.
    /// </summary>
    public string DevServerUri { get; set; } = string.Empty;

    /// <summary>
    /// Holt oder setzt den Pfad zum Vite-Manifest.
    /// </summary>
    public string ViteManifestPath { get; set; } = string.Empty;
}
