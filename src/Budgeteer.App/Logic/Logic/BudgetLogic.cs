// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="BudgetLogic.cs" company="Lukas Tietze">
// Copyright (c) Lukas Tietze. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------------------------------

namespace Budgeteer.App.Logic.Logic;

using System.Collections.Generic;
using System.Threading.Tasks;

using Budgeteer.App.Data;
using Budgeteer.App.Data.Entities;
using Budgeteer.App.Models.Setup.Budget;
using Budgeteer.Lib.Rest;

/// <summary>
/// Stellt die REST-Logik zum Verwalten von Budgets bereit.
/// </summary>
/// <param name="context">Der zu nutzende Datenbankkontext.</param>
/// <param name="logger">Der zu nutzende Logger.</param>
public class BudgetLogic(AppDbContext context, ILogger<BudgetLogic> logger) : RestRessourceLogicBase<EditModel, Budget, AppDbContext>(context, logger)
{
    /// <inheritdoc/>
    public override Task<EditModel?> GetAsync(int id) => throw new NotImplementedException();

    /// <inheritdoc/>
    public override Task<ICollection<object>> ListAsync(QueryRange? pagination) => throw new NotImplementedException();

    /// <inheritdoc/>
    protected override Task UpdateAsync(Budget entity, EditModel model) => throw new NotImplementedException();
}
