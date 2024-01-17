// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="TagToBudget.cs" company="Lukas Tietze">
// Copyright (c) Lukas Tietze. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------------------------------

namespace Budgeteer.App.Data.Entities;

/// <summary>
/// Stellt die Mapping-Tabelle zwischen Schlagwörtern und Budgets dar.
/// </summary>
public class TagToBudget
{
    /// <summary>
    /// Holt oder setzt das verknüpfte Budget.
    /// </summary>
    public Budget? Budget { get; set; }

    /// <summary>
    /// Holt oder setzt die ID des verknüpften Budgets.
    /// </summary>
    public int BudgetId { get; set; }

    /// <summary>
    /// Holt oder setzt das verknüpfte Schlagwort.
    /// </summary>
    public Tag? Tag { get; set; }

    /// <summary>
    /// Holt oder setzt die ID des verknüpften Schlagworts.
    /// </summary>
    public int TagId { get; set; }
}
