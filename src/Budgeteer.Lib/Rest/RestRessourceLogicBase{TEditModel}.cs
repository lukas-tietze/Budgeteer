// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="RestRessourceLogicBase{TEditModel}.cs" company="Lukas Tietze">
// Copyright (c) Lukas Tietze. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------------------------------

namespace Budgeteer.Lib.Rest;

/// <summary>
/// Stellt die Basis für Logiken bereit, die eine REST-Funktionalität umsetzen.
/// </summary>
/// <typeparam name="TEditModel">Der Typ des Modells, das zur Bearbeitung von Daten empfangen wird.</typeparam>
public abstract class RestRessourceLogicBase<TEditModel>(ILogger<RestRessourceLogicBase<TEditModel>> logger) : LogicBase(logger)
    where TEditModel : RestEditModel
{
    /// <summary>
    /// Holt ein Modell zur Bearbeitung des Datensatzes mit der gegebenen ID.
    /// </summary>
    /// <param name="id">Die ID des zu bearbeitenden Datensatzes.</param>
    /// <returns>Einen <see cref="Task{TResult}"/>, dessen Ergebnis das Modell zur Bearbeitung ist.</returns>
    public abstract Task<TEditModel?> GetAsync(int id);

    /// <summary>
    /// Listet alle Datensätze auf und wendet ggf. Pagination an.
    /// </summary>
    /// <param name="pagination">Die Einstellungen für Pageination.</param>
    /// <returns>Einen <see cref="Task{TResult}"/>, dessen Ergebnis die Liste der Modelle ist.</returns>
    public abstract Task<IReadOnlyCollection<object?>> ListAsync(QueryRange? pagination);

    /// <summary>
    /// Setzt einen Wert asynchron.
    /// </summary>
    /// <param name="model">Das Modell mit den aktualisierten Daten.</param>
    /// <returns>Einen <see cref="Task{TResult}"/>, dessen Ergebnis die ID des
    /// bearbeiteten oder neu angelegten Datensatzes ist.</returns>
    public abstract Task<int> SetAsync(TEditModel model);

    /// <summary>
    /// Löscht den Datensatz mit der gegebenen ID.
    /// </summary>
    /// <param name="id">Die ID des zu löschenden Datensatzes.</param>
    /// <returns>Einen <see cref="Task{TResult}"/>, dessen Ergebnis anzeigt,
    /// ob der Datensatz gefunden und gelöscht wurde nicht.</returns>
    public abstract Task<bool> DeleteAsync(int id);
}
