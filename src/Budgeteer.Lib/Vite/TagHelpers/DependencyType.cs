// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="DependencyType.cs" company="Lukas Tietze">
// Copyright (c) Lukas Tietze. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------------------------------

namespace Budgeteer.Lib.Vite.TagHelpers;

/// <summary>
/// Stellt Werte zur Klassifizierung von Abhängigkeiten eines Einstiegspunkts dar.
/// </summary>
public enum DependencyType
{
    /// <summary>
    /// Es handelt sich um eine JavaScript-Ressource.
    /// </summary>
    Script,

    /// <summary>
    /// Es handelt sich um ein CSS-Stylesheet.
    /// </summary>
    Style,

    /// <summary>
    /// Es handelt sich um eine sonstige Ressource.
    /// </summary>
    Asset,
}
