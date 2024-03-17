// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="RestRessourceControllerBase{TEditModel}.cs" company="Lukas Tietze">
// Copyright (c) Lukas Tietze. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------------------------------

namespace Budgeteer.Lib.Rest;

using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Stellt eine Basisklasse für einen Controller der REST-Api bereit.
/// </summary>
/// <typeparam name="TEditModel">Der Typ des Modells zum Bearbeiten von Einträgen.</typeparam>
public class RestRessourceControllerBase<TEditModel>(RestRessourceLogicBase<TEditModel> logic, ILogger logger) : ControllerBase
    where TEditModel : RestEditModel
{
    /// <summary>
    /// Holt den genutzten Logger.
    /// </summary>
    protected ILogger Logger { get; } = logger;

    /// <summary>
    /// Holt die genutzte Logik.
    /// </summary>
    protected RestRessourceLogicBase<TEditModel> Logic { get; } = logic;
    /// <summary>
    /// Löscht einen Eintrag.
    /// </summary>
    /// <param name="id">Die ID des zu löschenden Eintrags.</param>
    /// <returns>Einen <see cref="Task{TResult}"/>, dessen Ergebnis im Erfolgsfall
    /// 204 NoContent ist und sonst 404 Not Found.</returns>
    public virtual async Task<IActionResult> DeleteAsync(int id)
    {
        var deleted = await this.Logic.DeleteAsync(id);

        return deleted ? this.NoContent() : this.NotFound();
    }

    /// <summary>
    /// Ruft ein Modell zur Bearbeiten des Datensatzes mit der gegebenen ID ist.
    /// </summary>
    /// <param name="id">Die ID des zu bearbeitenden Eintrags.</param>
    /// <returns>Einen <see cref="Task{TResult}"/>, dessen Ergebnis im Erfolgsfall
    /// 200 OK mit dem Modell ist und sonst 404 NotFound.</returns>
    public virtual async Task<IActionResult> GetAsync(int id)
    {
        var model = await this.Logic.GetAsync(id);

        return model != null ? this.Ok(model) : this.NotFound();
    }

    /// <summary>
    /// Ruft eine Liste von Modellen ab.
    /// </summary>
    /// <returns>Einen <see cref="Task{TResult}"/>, dessen Ergebnis im Erfolgsfall
    /// 200 OK mit dem Modell ist und sonst .</returns>
    public virtual async Task<IActionResult> ListAsync()
    {
        var queryRange = default(QueryRange?);

        if (this.Request.Query.TryGetValue("page", out var pageStr) &&
            int.TryParse(pageStr, out var page) &&
            this.Request.Query.TryGetValue("page-size", out var pageSizeStr) &&
            int.TryParse(pageSizeStr, out var pageSize))
        {
            queryRange = new QueryPagination(page, pageSize);
        }
        else if (this.Request.Query.TryGetValue("start", out var startStr) &&
            int.TryParse(startStr, out var start) &&
            this.Request.Query.TryGetValue("count", out var countStr) &&
            int.TryParse(countStr, out var count))
        {
            queryRange = new(start, count);
        }

        var models = await this.Logic.ListAsync(queryRange);

        return this.Ok(new RestArrayResult
        {
            Values = models,
            Pagination = queryRange,
        });
    }

    /// <summary>
    /// Behandelt einen Post-Request.
    /// </summary>
    /// <param name="id">Die ID des bearbeiteten Datensatzes.</param>
    /// <param name="model">Das Modell mit den aktualisierten Daten.</param>
    /// <returns>Einen <see cref="Task{TResult}"/>, dessen Ergebnis 200 OK mit dem aktualisierten Modell ist.</returns>
    public virtual async Task<IActionResult> PostAsync(int id, [FromBody] TEditModel model)
    {
        model.Id = id;

        var resultModel = await this.Logic.SetAsync(model);

        return this.Ok(resultModel);
    }
}
