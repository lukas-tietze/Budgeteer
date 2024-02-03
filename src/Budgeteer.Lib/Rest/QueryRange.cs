// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="QueryRange.cs" company="Lukas Tietze">
// Copyright (c) Lukas Tietze. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------------------------------

namespace Budgeteer.Lib.Rest;

/// <summary>
/// Stellt Daten für Pagination von Listen dar.
/// </summary>
/// <param name="Start">Der Index des ersten angefragten Elements.</param>
/// <param name="Count">Die Anzahl der angefragten Elemente.</param>
public record class QueryRange(int Start, int Count)
{
}
