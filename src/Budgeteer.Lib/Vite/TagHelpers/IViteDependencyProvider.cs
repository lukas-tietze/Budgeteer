// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="IViteDependencyProvider.cs" company="Lukas Tietze">
// Copyright (c) Lukas Tietze. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------------------------------

namespace Budgeteer.Lib.Vite.TagHelpers;

using System.Collections.Generic;

/// <summary>
/// Implementierende Klassen listen Abhängigkeiten von Skripten auf,
/// die z.B. beim Bundling und Chunk-Splitting entstehen.
/// </summary>
public interface IViteDependencyProvider
{
    /// <summary>
    /// Listet die Pfade aller Abhängigkeiten des gegebenen Einstiegspunkts auf.
    /// </summary>
    /// <param name="entryPoint">Der gesuchte Einstiegspunkt.</param>
    /// <returns>Die Auflistung der Pfade der Abhängigkeiten.</returns>
    public IEnumerable<(DependencyType Type, string Path)> ListDependencies(string entryPoint);
}
