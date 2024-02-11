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
                ParentId = b.ParentId,
            })
            .FirstAsync();

        var tree = await this.Context.Budgets
            .Select(b => Tuple.Create(b.Id, b.ParentId, b.Name))
            .ToArrayAsync();

        var nodesById = tree.ToDictionary(t => t.Item1, t => new SelectableParentBudgetModel { Id = t.Item1, Label = t.Item3 });

        foreach (var (nodeId, nodeParentId, _) in tree)
        {
            nodesById[nodeParentId].Children.Add(nodesById[nodeId]);
        }

        var remove = new Stack<int>();

        remove.Push(model.Id);

        while (remove.TryPop(out var nextId))
        {
            nodesById.Remove(nextId);

            foreach (var removeChild in nodesById[nextId].Children)
            {
                remove.Push(removeChild.Id);
            }
        }

        model.SelectableParents = nodesById.Values;

        return model;
    }

    /// <inheritdoc/>
    public override Task<ICollection<object>> ListAsync(QueryRange? pagination)
    {
    }

    /// <inheritdoc/>
    protected override Task UpdateAsync(Budget entity, EditModel model) => throw new NotImplementedException();
}
