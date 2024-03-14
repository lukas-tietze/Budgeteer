// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="IBidirectionalTree{T}.cs" company="Lukas Tietze">
// Copyright (c) Lukas Tietze. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------------------------------

namespace Budgeteer.DataStructures.Tree;

/// <summary>
/// Stellt einen Baum dar, der auch Links nach oben hat.
/// </summary>
/// <typeparam name="T">Der Typ der Daten am Baum.</typeparam>
public interface IBidirectionalTree<T> : ITree<T>
{
    /// <summary>
    /// Holt den Elternknoten.
    /// </summary>
    public IBidirectionalTree<T>? Parent { get; }
}
