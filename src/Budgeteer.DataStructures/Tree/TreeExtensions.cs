// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="TreeExtensions.cs" company="Lukas Tietze">
// Copyright (c) Lukas Tietze. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------------------------------

namespace Budgeteer.DataStructures.Tree;

using System.Runtime.CompilerServices;

/// <summary>
/// Stellt Erweiterungen für <see cref="ITree{T}"/> und
/// <see cref="IBidirectionalTree{T}"/> bereit.
/// </summary>
internal class TreeExtensions
{
    /// <summary>
    /// Durchläuft den Baum vom aktuellen Knoten aus
    /// nach dem Breadth-First-Prinzip.
    /// </summary>
    /// <returns>Eine Auflistung der Knoten.</returns>
    IEnumerable<BasicTree<T>> EnumerateBreadthFirst();

    /// <summary>
    /// Durchläuft die Daten des Baums vom aktuellen Knoten aus
    /// nach dem Breadth-First-Prinzip.
    /// </summary>
    /// <returns>Eine Auflistung der Daten der Knoten.</returns>
    IEnumerable<T> EnumerateDataBreadthFirst();

    /// <summary>
    /// Durchläuft die Daten des Baums vom aktuellen Knoten aus
    /// nach dem Depth-First-Prinzip.
    /// </summary>
    /// <returns>Eine Auflistung der Daten der Knoten.</returns>
    IEnumerable<T> EnumerateDataDepthFirst();

    /// <summary>
    /// Durchläuft den Baum vom aktuellen Knoten aus horizontal,
    /// also jeweils vom ersten Knoten einer Ebene bis zum letzten und
    /// gibt dabei nur die Daten der Knoten aus.
    /// Der aktuelle Knoten stellt dabei die erste Ebene dar, die Ebenen
    /// werden von oben nach unten durchlaufen.
    /// </summary>
    /// <returns>Eine Auflistung der Daten der Knoten.</returns>
    IEnumerable<T> EnumerateDataHorizontal();

    /// <summary>
    /// Durchläuft den Baum vom aktuellen Knoten aus
    /// nach dem Depth-First-Prinzip.
    /// </summary>
    /// <returns>Eine Auflistung der Knoten.</returns>
    /// <inheritdoc/>
    public IEnumerable<TTree> EnumerateDepthFirst<TTree, TTreeData>(this TTree tree)
        where TTree : ITree<TTreeData>
    {
        var stack = new Stack<TTree>();

        stack.Push(tree);

        while (stack.TryPop(out var node))
        {
            yield return node;

            foreach (var child in node.Children)
            {
                stack.Push(child);
            }
        }
    }

    /// <summary>
    /// Durchläuft den Baum vom aktuellen Knoten aus horizontal,
    /// also jeweils vom ersten Knoten einer Ebene bis zum letzten.
    /// Der aktuelle Knoten stellt dabei die erste Ebene dar, die Ebenen
    /// werden von oben nach unten durchlaufen.
    /// </summary>
    /// <returns>Eine Auflistung der Knoten.</returns>
    IEnumerable<BasicTree<T>> EnumerateHorizontal();
}
