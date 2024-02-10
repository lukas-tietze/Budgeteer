// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="ViteManifestEntry.cs" company="Lukas Tietze">
// Copyright (c) Lukas Tietze. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------------------------------

namespace Budgeteer.Lib.Vite;

using System;

using Newtonsoft.Json;

/// <summary>
/// Stellt einen Eintrag des Vite-Manifests dar.
/// </summary>
internal class ViteManifestEntry
{
    /// <summary>
    /// Holt oder setzt die Sammlung der von der Datei importierten Assets.
    /// </summary>
    [JsonProperty("assets")]
    public string[] Assets { get; set; } = [];

    /// <summary>
    /// Holt oder setzt den PFad zur Datei, die diese Ressource enthält.
    /// </summary>
    [JsonProperty("file")]
    public string File { get; set; } = string.Empty;

    /// <summary>
    /// Holt oder setzt die Sammlung der dynamischen Importe der Datei.
    /// </summary>
    [JsonProperty("dynamicImports")]
    public string[] Scripts { get; set; } = [];

    /// <summary>
    /// Holt oder setzt die Sammlung der von der Datei importierten Stylesheets.
    /// </summary>
    [JsonProperty("css")]
    public string[] Styles { get; set; } = [];
}
