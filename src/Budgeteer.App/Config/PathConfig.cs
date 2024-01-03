// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="PathConfig.cs" company="Lukas Tietze">
// Copyright (c) Lukas Tietze. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------------------------------

namespace Budgeteer.App.Config;

/// <summary>
/// Stellt die Konfiguration verschiedener Pfade bereit.
/// </summary>
public class PathConfig
{
    /// <summary>
    /// Holt oder setzt den Wert für &lt;base href="..."/&gt;.
    /// </summary>
    public string BaseHref { get; set; } = string.Empty;
}
