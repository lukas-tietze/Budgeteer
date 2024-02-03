// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="EditModel.cs" company="Lukas Tietze">
// Copyright (c) Lukas Tietze. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------------------------------

namespace Budgeteer.App.Models.Setup.Budget;

using Budgeteer.Lib.Rest;

/// <summary>
/// Modelliert die Daten zum Bearbeiten eines Budgets.
/// </summary>
public class EditModel : RestEditModel
{
    /// <summary>
    /// Holt oder setzt den Betrag in Cent.
    /// </summary>
    public long Amount { get; set; }

    /// <summary>
    /// Holt oder setzt die Bezeichnung des Budgets.
    /// </summary>
    public string Label { get; set; } = string.Empty;

    /// <summary>
    /// Holt oder setzt das ausgewählte Eltern-Element.
    /// </summary>
    public int ParentId { get; set; }

    /// <summary>
    /// Holt oder setzt die Sammlung der möglichen Elternelemente.
    /// </summary>
    public IEnumerable<SelectableParentBudgetModel> SelectableParents { get; set; } = Enumerable.Empty<SelectableParentBudgetModel>();
}
