// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="ViteManifest.cs" company="Lukas Tietze">
// Copyright (c) Lukas Tietze. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------------------------------

namespace Budgeteer.Lib.Vite;

using System.Collections.Generic;
using System.IO;
using System.Linq;

using Budgeteer.Lib.Vite.TagHelpers;

using Microsoft.Extensions.Logging;

using Newtonsoft.Json;

/// <summary>
/// Stellt das Vite-Manifest dar, das ggf. aus dem wwwroot-Ordner ausgelesen wurde.
/// </summary>
internal class ViteManifest : IViteDependencyProvider
{
    /// <summary>
    /// Die aktuelle Vite-Konfiguration.
    /// </summary>
    private readonly ViteConfig config;

    /// <summary>
    /// Enthält alle Einträge des Manifests.
    /// </summary>
    private readonly Dictionary<string, ViteManifestEntry> entries;

    /// <summary>
    /// Der genutzte Logger.
    /// </summary>
    private readonly ILogger<ViteManifest> logger;

    /// <summary>
    /// Initialisiert eine neue Instanz der <see cref="ViteManifest"/> Klasse.
    /// </summary>
    /// <param name="logger">Der zu nutzende Logger.</param>
    /// <param name="config">Die zu nutzende Vite-Konfiguration.</param>
    public ViteManifest(ILogger<ViteManifest> logger, ViteConfig config)
    {
        this.logger = logger;
        this.config = config;
        this.entries = this.ReadManifest() ?? new();
    }

    /// <summary>
    /// Ruft den Eintrag für die Ressource mit dem gegebenen
    /// Pfad ab. Falls eine solche Ressource nicht im Manifest
    /// gefunden wurde, wird ein Eintrag mit Standardwerten
    /// zurückgegeben.
    /// </summary>
    /// <param name="ressourcePath">Der Pfad der gesuchten Ressource.</param>
    /// <returns>Der Eintrag für die Ressource.</returns>
    public ViteManifestEntry this[string ressourcePath] =>
        this.entries.GetValueOrDefault(ressourcePath) ?? new ViteManifestEntry { File = ressourcePath };

    /// <inheritdoc/>
    public IEnumerable<(DependencyType Type, string Path)> ListDependencies(string entryPoint)
    {
        var entry = this[entryPoint];

        var list = new List<(DependencyType Type, string Path)>();

        list.AddRange(entry.Assets.Select(e => (DependencyType.Asset, e)));
        list.AddRange(entry.Styles.Select(e => (DependencyType.Style, e)));

        return list;
    }

    /// <summary>
    /// Liest das Vite-Manifest aus und gibt entweder die gelesenen
    /// Eintäge zurück oder null, wenn das Manifest nicht vorhanden war oder nicht
    /// genutzt werden soll.
    /// </summary>
    /// <returns>Die gelesenen Manifest-Einträge oder null, wenn kein Manifest nötig oder vorhanden ist.</returns>
    private Dictionary<string, ViteManifestEntry>? ReadManifest()
    {
        if (this.config.StaticFileConfiguration is null)
        {
            this.logger.LogInformation("Using vite dev server, vite manifest will be ignored.");

            return null;
        }

        var file = this.config.StaticFileConfiguration.ViteManifestPath;

        this.logger.LogInformation($"Reading vite manifest. Provided path \"{file}\"");

        if (string.IsNullOrEmpty(file))
        {
            file = Path.GetFullPath(Path.Combine("wwwroot", "manifest.json"));

            this.logger.LogInformation($"No manifest path provided, using fallback \"{file}\"");
        }

        try
        {
            var text = File.ReadAllText(file);
            var res = JsonConvert.DeserializeObject<Dictionary<string, ViteManifestEntry>>(text);

            this.logger.LogInformation($"Read vite manifest from \"{file}\" -> {res?.Count ?? 0} entries.");

            return res;
        }
        catch
        {
            this.logger.LogError($"Failed to read vite manifest from \"{file}\"");

            return null;
        }
    }
}
