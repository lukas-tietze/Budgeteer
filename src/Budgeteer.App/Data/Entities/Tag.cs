// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="Tag.cs" company="Lukas Tietze">
// Copyright (c) Lukas Tietze. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------------------------------

namespace Budgeteer.App.Data.Entities;

using System.ComponentModel.DataAnnotations;

/// <summary>
/// Stellt ein Schlagwort dar, das belibig verteilt verteilt werden kann.
/// </summary>
public class Tag : TimerEntityBase
{
    /// <summary>
    /// Holt oder setzt den Text des Tags.
    /// </summary>
    [MaxLength(255)]
    public string Name { get; set; } = string.Empty;
}
