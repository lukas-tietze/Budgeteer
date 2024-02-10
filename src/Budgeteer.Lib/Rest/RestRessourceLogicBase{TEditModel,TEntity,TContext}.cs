// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="RestRessourceLogicBase{TEditModel,TEntity,TContext}.cs" company="Lukas Tietze">
// Copyright (c) Lukas Tietze. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------------------------------

namespace Budgeteer.Lib.Rest;

using Microsoft.EntityFrameworkCore;

/// <summary>
/// Stellt eine Basis für Logiken dar, die REST-Dienste implementierén.
/// </summary>
/// <typeparam name="TEditModel">Der Typ des Modells, das zur Bearbeitung empfangen wird.</typeparam>
/// <typeparam name="TEntity">Der Typ der Entität, die bearbeitet wird.</typeparam>
/// <typeparam name="TContext">Der Typ des genutzten Datenbankkontextes.</typeparam>
public abstract class RestRessourceLogicBase<TEditModel, TEntity, TContext>(TContext context, ILogger<RestRessourceLogicBase<TEditModel, TEntity, TContext>> logger)
    : RestRessourceLogicBase<TEditModel>(logger)
    where TEditModel : RestEditModel
    where TEntity : RestEntityBase, new()
    where TContext : DbContext
{
    /// <summary>
    /// Holt den genutzten Datenbankkontext.
    /// </summary>
    protected TContext Context { get; } = context;

    /// <inheritdoc/>
    public override async Task<bool> DeleteAsync(int id)
    {
        await this.DeleteDependenciesAsync(id);

        var deleted = await this.Context.Set<TEntity>()
            .Where(e => e.Id == id)
            .ExecuteDeleteAsync();

        return deleted > 0;
    }

    /// <inheritdoc/>
    public override async Task<int> SetAsync(TEditModel model)
    {
        TEntity entity;

        if (model.Id == default)
        {
            entity = new();

            this.Context.Add(entity);
        }
        else
        {
            entity = await this.Context.Set<TEntity>().FirstAsync(v => v.Id == model.Id);
        }

        await this.UpdateAsync(entity, model);

        await this.Context.SaveChangesAsync();

        return entity.Id;
    }

    /// <summary>
    /// Kann in ableitenden Klassen überschrieben werden, um Abhängigkeiten
    /// einer Entität zu löschen.
    /// </summary>
    /// <param name="id">Die ID der gelöschten Entität.</param>
    /// <returns>Einen <see cref="Task{TResult}"/>, der die asynchrone Bearbeitung der Methode darstellt.</returns>
    protected virtual Task DeleteDependenciesAsync(int id) => Task.CompletedTask;

    /// <summary>
    /// Aktualisiert eine Entität aus einem Modell.
    /// </summary>
    /// <param name="entity">Die zu aktualisierende Entität.</param>
    /// <param name="model">Das Modell mit den aktualisierten Daten.</param>
    /// <returns>Einen <see cref="Task{TResult}"/>, der die asynchrone Bearbeitung der Methode darstellt.</returns>
    protected abstract Task UpdateAsync(TEntity entity, TEditModel model);
}
