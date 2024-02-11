// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="IBidirectionalTree{T}.cs" company="Lukas Tietze">
// Copyright (c) Lukas Tietze. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------------------------------

namespace Budgeteer.DataStructures.Tree;

public interface IBidirectionalTree<T> : ITree<T>
{
    public IBidirectionalTree<T>? Parent { get; }
}
