// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="ModelBase.cs" company="Lukas Tietze">
// Copyright (c) Lukas Tietze. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------------------------------

namespace Budgeteer.App.Models;

/// <summary>
/// Stellt die Basis für Modelle dar.
/// </summary>
public class ModelBase
{
    /// <summary>
    /// Holt oder setzt die ID.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Holt oder setzt die Bezeichnung.
    /// </summary>
    public string Label { get; set; } = string.Empty;
}
