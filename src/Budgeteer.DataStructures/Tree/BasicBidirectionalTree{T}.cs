// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="BasicBidirectionalTree{T}.cs" company="Lukas Tietze">
// Copyright (c) Lukas Tietze. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------------------------------

namespace Budgeteer.DataStructures;

using Budgeteer.DataStructures.Tree;

/// <summary>
/// Stellt einen Knoten einer Baumstruktur dar.
/// </summary>
/// <typeparam name="T">Der Typ der Daten des Baums.</typeparam>
public class BasicBidirectionalTree<T>(T data) : BasicTree<T>(data), IBidirectionalTree<T>
{
    /// <inheritdoc/>
    public IBidirectionalTree<T> Parent { get; set; }
}
