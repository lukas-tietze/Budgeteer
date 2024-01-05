// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="EntityBase.cs" company="Lukas Tietze">
// Copyright (c) Lukas Tietze. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------------------------------

namespace Budgeteer.App.Data.Entities;

using System.ComponentModel.DataAnnotations;

using Microsoft.EntityFrameworkCore;

/// <summary>
/// Stellt die Basis aller Entitäten dar.
/// </summary>
public class EntityBase
{
    /// <summary>
    /// Holt oder setzt die eindeutige Nummer des Eintrags.
    /// </summary>
    [Key]
    public int Id { get; set; }
}
