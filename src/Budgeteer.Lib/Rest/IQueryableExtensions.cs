// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="IQueryableExtensions.cs" company="Lukas Tietze">
// Copyright (c) Lukas Tietze. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------------------------------

namespace Budgeteer.Lib.Rest;

/// <summary>
/// Stellt Erweiterungen für <see cref="IQueryable{T}"/> bereit.
/// </summary>
public static class IQueryableExtensions
{
    /// <summary>
    /// Wendet Pagination auf ein Query an.
    /// </summary>
    /// <typeparam name="T">De Typ der angefragten Elemente.</typeparam>
    /// <param name="query">Das Query, auf das Pagination angewandt werden soll.</param>
    /// <param name="pagination">Die Pagination-Daten.</param>
    /// <returns>Das modifizierte Query.</returns>
    public static IQueryable<T> Paginate<T>(this IQueryable<T> query, QueryRange pagination) =>
        query.Skip(pagination.Start).Take(pagination.Count);
}
