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
public static class TreeExtensions
{
    /// <summary>
    /// Durchläuft den Baum vom aktuellen Knoten aus
    /// nach dem Breadth-First-Prinzip.
    /// </summary>
    /// <returns>Eine Auflistung der Knoten.</returns>
    public static IEnumerable<BasicTree<T>> EnumerateBreadthFirst()
    {
        var queue = new Queue<BasicTree<T>>();

        queue.Enqueue(this);

        while (queue.TryDequeue(out var node))
        {
            yield return node.Data;

            foreach (var child in node.children)
            {
                queue.Enqueue(child);
            }
        }
    }

    /// <summary>
    /// Durchläuft die Daten des Baums vom aktuellen Knoten aus
    /// nach dem Breadth-First-Prinzip.
    /// </summary>
    /// <returns>Eine Auflistung der Daten der Knoten.</returns>
    public static IEnumerable<T> EnumerateDataBreadthFirst<T>(this ITree<T> root)
    {
        var queue = new Queue<ITree<T>>();

        queue.Enqueue(root);

        while (queue.TryDequeue(out var node))
        {
            yield return node.Data;

            foreach (var child in node.Children)
            {
                queue.Enqueue(child);
            }
        }
    }


    /// <summary>
    /// Durchläuft die Daten des Baums vom aktuellen Knoten aus
    /// nach dem Depth-First-Prinzip.
    /// </summary>
    /// <returns>Eine Auflistung der Daten der Knoten.</returns>
    public static IEnumerable<T> EnumerateDataDepthFirst<T>(this ITree<T> root)
    {
        var stack = new Stack<ITree<T>>();

        stack.Push(root);

        while (stack.TryPop(out var node))
        {
            yield return node.Data;

            foreach (var child in node.Children)
            {
                stack.Push(child);
            }
        }
    }

    /// <summary>
    /// Durchläuft den Baum vom aktuellen Knoten aus
    /// nach dem Depth-First-Prinzip.
    /// </summary>
    /// <returns>Eine Auflistung der Knoten.</returns>
    /// <inheritdoc/>
    public static IEnumerable<TTree> EnumerateDepthFirst<TTree, TTreeData>(this TTree tree)
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
}
