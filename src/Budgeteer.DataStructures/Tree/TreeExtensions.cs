// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="TreeExtensions.cs" company="Lukas Tietze">
// Copyright (c) Lukas Tietze. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------------------------------

namespace Budgeteer.DataStructures.Tree;

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
    /// <param name="root">Der Knoten, vom dem aus die Iteration beginnt.</param>
    /// <typeparam name="T">Der Typ der Daten im Baum.</typeparam>
    /// <returns>Eine Auflistung der Knoten.</returns>
    public static IEnumerable<ITree<T>> EnumerateBreadthFirst<T>(this ITree<T> root)
    {
        var queue = new Queue<ITree<T>>();

        queue.Enqueue(root);

        while (queue.TryDequeue(out var node))
        {
            yield return node;

            foreach (var child in node.Children)
            {
                queue.Enqueue(child);
            }
        }
    }

    /// <summary>
    /// Durchläuft die Daten des Baums vom aktuellen Knoten aus
    /// nach dem Breadth-First-Prinzip.
    /// </summary>
    /// <param name="root">Der Knoten, vom dem aus die Iteration beginnt.</param>
    /// <typeparam name="T">Der Typ der Daten im Baum.</typeparam>
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
    /// <param name="root">Der Knoten, vom dem aus die Iteration beginnt.</param>
    /// <typeparam name="T">Der Typ der Daten im Baum.</typeparam>
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
    /// Durchläuft die Daten des Baums vom aktuellen Knoten aus
    /// nach oben, bis zur Wurzel.
    /// </summary>
    /// <param name="root">Der Knoten, vom dem aus die Iteration beginnt.</param>
    /// <typeparam name="T">Der Typ der Daten im Baum.</typeparam>
    /// <returns>Eine Auflistung der Daten der Knoten.</returns>
    public static IEnumerable<T> ENumerateDataUpwards<T>(this IBidirectionalTree<T> root)
    {
        var node = root;

        while (node != null)
        {
            yield return node.Data;

            node = node.Parent;
        }
    }

    /// <summary>
    /// Durchläuft den Baum vom aktuellen Knoten aus
    /// nach dem Depth-First-Prinzip.
    /// </summary>
    /// <param name="root">Der Knoten, vom dem aus die Iteration beginnt.</param>
    /// <typeparam name="T">Der Typ der Daten im Baum.</typeparam>
    /// <returns>Eine Auflistung der Knoten.</returns>
    public static IEnumerable<ITree<T>> EnumerateDepthFirst<T>(this ITree<T> root)
    {
        var stack = new Stack<ITree<T>>();

        stack.Push(root);

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
    /// Durchläuft den Baum vom aktuellen Knoten aus
    /// nach oben bis zur Wurzel.
    /// </summary>
    /// <param name="root">Der Knoten, vom dem aus die Iteration beginnt.</param>
    /// <typeparam name="T">Der Typ der Daten im Baum.</typeparam>
    /// <returns>Eine Auflistung der Knoten.</returns>
    public static IEnumerable<IBidirectionalTree<T>> EnumerateUpwards<T>(this IBidirectionalTree<T> root)
    {
        var node = root;

        while (node != null)
        {
            yield return node;

            node = node.Parent;
        }
    }

    /// <summary>
    /// Entfernt den aktuellen Knoten aus dem Eltern-Knoten.
    /// </summary>
    /// <param name="node">Der zu entfernende Knoten.</param>
    /// <typeparam name="T">Der Typ der Daten im Baum.</typeparam>
    public static void Remove<T>(this IBidirectionalTree<T> node) => node.Parent?.RemoveChild(node);
}