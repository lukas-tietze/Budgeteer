// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="TagToBudget.cs" company="Lukas Tietze">
// Copyright (c) Lukas Tietze. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------------------------------

namespace Budgeteer.App.Data.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

/// <summary>
/// Stellt die Mapping-Tabelle zwischen Schlagwörtern und Budgets dar.
/// </summary>
[PrimaryKey(nameof(BudgetId), nameof(TagId))]
[Table(nameof(TagToBudget), Schema = "Budgeteer.Setup")]
public class TagToBudget
{
    /// <summary>
    /// Holt oder setzt das verknüpfte Budget.
    /// </summary>
    public Budget? Budget { get; set; }

    /// <summary>
    /// Holt oder setzt die ID des verknüpften Budgets.
    /// </summary>
    [ForeignKey(nameof(Budget))]
    public int BudgetId { get; set; }

    /// <summary>
    /// Holt oder setzt das verknüpfte Schlagwort.
    /// </summary>
    public Tag? Tag { get; set; }

    /// <summary>
    /// Holt oder setzt die ID des verknüpften Schlagworts.
    /// </summary>
    [ForeignKey(nameof(Tag))]
    public int TagId { get; set; }
}
