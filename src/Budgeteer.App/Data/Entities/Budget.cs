// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="Budget.cs" company="Lukas Tietze">
// Copyright (c) Lukas Tietze. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------------------------------

namespace Budgeteer.App.Data.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

/// <summary>
/// Stellt ein konkret geplantes Budget dar.
/// </summary>
internal class Budget : PrincipalEntityBase
{
    /// <summary>
    /// Holt oder setzt die ggf. zugeordnete Kategorie.
    /// </summary>
    public Budget? Parent { get; set; }

    /// <summary>
    /// Holt oder setzt die ID der ggf. zugeordneten Kategorie.
    /// </summary>
    [ForeignKey(nameof(Parent))]
    public int ParentId { get; set; }

    /// <summary>
    /// Holt oder setzt die Bezeichnung dieses Budgets.
    /// </summary>
    [MaxLength(255)]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Holt oder setzt den Betrag des Budgets.
    /// </summary>
    public long Amount { get; set; }
}
