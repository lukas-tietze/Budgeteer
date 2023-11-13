// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="IServiceCollectionExtension.cs" company="Lukas Tietze">
// Copyright (c) Lukas Tietze. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------------------------------

namespace Budgeteer.Lib.Vite;

using System;

using Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Stellt Erweiterungen für <see cref="IServiceCollection"/> zur Verfügung.
/// </summary>
public static class IServiceCollectionExtension
{
    /// <summary>
    /// Fügt Vite zum Programm hinzu, sodass die Vite-Tag-Helper funktionieren.
    /// </summary>
    /// <param name="services">Der zu bearbeitende DI-Container.</param>
    /// <param name="config">Die zu nutzende Konfiguration.</param>
    /// <returns><paramref name="services"/>, um Method-Chaining zu ermöglichen.</returns>
    public static IServiceCollection AddVite(this IServiceCollection services, ViteConfig config) => services
        .AddSingleton(config)
        .AddSingleton<IViteUriProvider, ViteUriProvider>()
        .AddSingleton<ViteManifest>();
}
