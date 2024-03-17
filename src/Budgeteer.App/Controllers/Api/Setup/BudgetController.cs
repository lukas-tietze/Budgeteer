// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="BudgetController.cs" company="Lukas Tietze">
// Copyright (c) Lukas Tietze. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------------------------------

namespace Budgeteer.App.Controllers.Api.Setup;

using Budgeteer.App.Logic.Api.Setup;
using Budgeteer.App.Models.Setup.Budget;
using Budgeteer.Lib.Rest;

using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Stellt die REST-API für Budgets bereit.
/// </summary>
[ApiRoute("budget")]
public class BudgetController(BudgetLogic logic, ILogger<BudgetController> logger) : RestRessourceControllerBase<EditModel>(logic, logger)
{
    [HttpGet("edit/{id}")]
    public async override Task<IActionResult> GetAsync(int id) => await base.GetAsync(id);

    [HttpGet]
    public async override Task<IActionResult> ListAsync() => await base.ListAsync();

    [HttpPost("edit/{id}")]
    public async override Task<IActionResult> PostAsync([FromRoute] int id, [FromBody] EditModel model) => await base.PostAsync(id, model);
}
