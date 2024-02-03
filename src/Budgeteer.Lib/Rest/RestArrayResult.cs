// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="RestArrayResult.cs" company="Lukas Tietze">
// Copyright (c) Lukas Tietze. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------------------------------

namespace Budgeteer.Lib.Rest;

/// <summary>
/// Stellt das Ergebnis einer RESTR-Funktion dar, die ein Array liefert.
/// </summary>
/// <typeparam name="T">Der Typ der Array-Elemente.</typeparam>
public class RestArrayResult<T>
{
    /// <summary>
    /// Holt oder setzt die Parameter der ggf. angewandten Pagination.
    /// </summary>
    public QueryRange? Pagination { get; set; }

    /// <summary>
    /// Holt oder setzt die enthaltenen Werte.
    /// </summary>
    public IEnumerable<T> Values { get; set; } = Enumerable.Empty<T>();
}
