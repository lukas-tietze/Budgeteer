// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="ViteManifestEntry.cs" company="Lukas Tietze">
// Copyright (c) Lukas Tietze. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------------------------------

namespace Budgeteer.Lib.Vite;

using System.Text.Json.Serialization;

/// <summary>
/// Stellt einen Eintrag des Vite-Manifests dar.
/// </summary>
internal class ViteManifestEntry
{
    /// <summary>
    /// Initialisiert eine neue Instanz der <see cref="ViteManifestEntry"/> Klasse.
    /// </summary>
    protected internal ViteManifestEntry()
    {
        this.File = string.Empty;
    }

    /// <summary>
    /// Holt oder setzt den PFad zur Datei, die diese Ressource enthält.
    /// </summary>
    [JsonPropertyName("file")]
    public string File
    {
        get;
        set;
    }
}
