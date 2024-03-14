// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="BudgetLogic.cs" company="Lukas Tietze">
// Copyright (c) Lukas Tietze. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------------------------------

namespace Budgeteer.App.Logic.Api.Setup;

using System.Collections.Generic;
using System.Threading.Tasks;

using Budgeteer.App.Data;
using Budgeteer.App.Data.Entities;
using Budgeteer.App.Models.Setup.Budget;
using Budgeteer.DataStructures.Tree;
using Budgeteer.Lib.Rest;

using Microsoft.EntityFrameworkCore;

/// <summary>
/// Stellt die REST-Logik zum Verwalten von Budgets bereit.
/// </summary>
/// <param name="context">Der zu nutzende Datenbankkontext.</param>
/// <param name="logger">Der zu nutzende Logger.</param>
public class BudgetLogic(AppDbContext context, ILogger<BudgetLogic> logger) : RestRessourceLogicBase<EditModel, Budget, AppDbContext>(context, logger)
{
    /// <inheritdoc/>
    public override async Task<EditModel?> GetAsync(int id)
    {
        var model = await this.Context.Budgets
            .Where(b => b.Id == id)
            .Select(b => new EditModel
            {
                Id = b.Id,
                Amount = b.Amount,
                Label = b.Name,
                ParentId = b.ParentId ?? 0,
            })
            .FirstAsync();

        var tree = await this.GetBudgetTreeAsync();

        (tree.EnumerateBreadthFirst().FirstOrDefault(node => node.Data.Id == model.Id) as IBidirectionalTree<TreeData>)?.Remove();

        var selectableParentModels = tree.ToDataTree(
            childrenGetter: node => node.Children,
            nodeFactory: node => new SelectableParentBudgetModel
            {
                Id = node.Id,
                Label = node.Name,
            });

        model.SelectableParents = selectableParentModels.Children;

        return model;
    }

    /// <inheritdoc/>
    public override async Task<IReadOnlyCollection<object?>> ListAsync(QueryRange? pagination)
    {
        var tree = await this.GetBudgetTreeAsync();
        var rootModel = tree.ToDataTree(
            childrenGetter: node => node.Children,
            nodeFactory: node => new ListModel
            {
                Id = node.Id,
                Label = node.Name,
                Amount = node.Amount,
            });

        return rootModel.Children;
    }

    /// <inheritdoc/>
    protected override Task UpdateAsync(Budget entity, EditModel model) => throw new NotImplementedException();

    /// <summary>
    /// Ruft die Daten der Budgets des aktuellen Nutzers in Baumstruktur ab.
    /// </summary>
    /// <returns>Einen <see cref="Task{TResult}"/>, dessen Ergebnis die Baumstruktur ist.</returns>
    private async Task<IBidirectionalTree<TreeData>> GetBudgetTreeAsync()
    {
        var treeData = await this.Context.Budgets
            .Select(b => new TreeData
            {
                Id = b.Id,
                ParentId = b.ParentId ?? 0,
                Name = b.Name,
                Amount = b.Amount,
            })
            .ToArrayAsync();

        return treeData.ToTree(i => i.Id, i => i.ParentId);
    }

    /// <summary>
    /// Stellt die Daten für die baumartige Darstellung der Budgets dar.
    /// </summary>
    private class TreeData
    {
        /// <summary>
        /// Holt oder setzt den eingestellten Betrag des Budgets.
        /// </summary>
        public long Amount { get; set; }

        /// <summary>
        /// Holt oder setzt die ID des Datensatzes.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Holt oder setzt die Bezeichnung des Datensatzes.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Holt oder setzt die ID des übergeordneten Budgets.
        /// </summary>
        public int ParentId { get; set; }
    }
}
