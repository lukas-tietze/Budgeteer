// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="SelectableParentBudgetModel.cs" company="Lukas Tietze">
// Copyright (c) Lukas Tietze. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------------------------------

namespace Budgeteer.App.Models.Setup.Budget;

/// <summary>
/// Modelliert ein Budget, das als übergeordnetes Budget
/// ausgewählt werden kann.
/// </summary>
public class SelectableParentBudgetModel
{
    /// <summary>
    /// Holt oder setzt die ID des Budgets.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Holt oder setzt die Bezeichnung des Budgets.
    /// </summary>
    public string Label { get; set; } = string.Empty;
}
