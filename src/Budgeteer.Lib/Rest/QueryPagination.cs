// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="QueryPagination.cs" company="Lukas Tietze">
// Copyright (c) Lukas Tietze. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------------------------------

namespace Budgeteer.Lib.Rest;

/// <summary>
/// Stellt Daten für Pagination von Listen dar.
/// </summary>
/// <param name="Page">Der Index der gesuchten Seite.</param>
/// <param name="PageSize">Die Anzahl der Elemente pro Seite.</param>
public record class QueryPagination(int Page, int PageSize)
{
    /// <summary>
    /// Ermöglicht die implizite Konvertierung in eine <see cref="QueryRange"/>-Intsanz.
    /// </summary>
    /// <param name="pagination">Die zu konvertierende Instanz.</param>
    public static implicit operator QueryRange(QueryPagination pagination) =>
        new(pagination.Page * pagination.PageSize, pagination.PageSize);
}
