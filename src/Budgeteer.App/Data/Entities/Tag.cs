// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="Tag.cs" company="Lukas Tietze">
// Copyright (c) Lukas Tietze. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------------------------------

namespace Budgeteer.App.Data.Entities;

/// <summary>
/// Stellt ein Schlagwort dar, das belibig verteilt verteilt werden kann.
/// </summary>
public class Tag : PrincipalEntityBase
{
    /// <summary>
    /// Holt oder setzt den Text des Tags.
    /// </summary>
    public string Name { get; set; } = string.Empty;
}
