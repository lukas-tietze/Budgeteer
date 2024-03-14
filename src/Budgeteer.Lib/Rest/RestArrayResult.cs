// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="RestArrayResult.cs" company="Lukas Tietze">
// Copyright (c) Lukas Tietze. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------------------------------

namespace Budgeteer.Lib.Rest;

/// <summary>
/// Stellt das Ergebnis einer RESTR-Funktion dar, die ein Array liefert.
/// </summary>
public class RestArrayResult
{
    /// <summary>
    /// Holt oder setzt die Parameter der ggf. angewandten Pagination.
    /// </summary>
    public QueryRange? Pagination { get; set; }

    /// <summary>
    /// Holt oder setzt die enthaltenen Werte.
    /// </summary>
    public IEnumerable<object?> Values { get; set; } = [];
}
