// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="ListModel.cs" company="Lukas Tietze">
// Copyright (c) Lukas Tietze. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------------------------------

namespace Budgeteer.App.Models.Setup.Budget;

/// <summary>
/// Modelliert die Daten zum Auflisten von Budgets.
/// </summary>
public class ListModel : ModelBase
{
    /// <summary>
    /// Holt oder setzt Betrag des Budgets.
    /// </summary>
    public long Amount { get; set; }

    /// <summary>
    /// Holt oder setzt die Sammlung der untergeordneten Budgets.
    /// </summary>
    public IEnumerable<ListModel> Children { get; set; } = Enumerable.Empty<ListModel>();
}
