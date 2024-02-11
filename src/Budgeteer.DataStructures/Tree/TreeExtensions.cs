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

    /// <summary>
    /// Erzeugt eine Basumstruktur aus den gegebenen Daten.
    /// </summary>
    /// <typeparam name="T">De Typ der Daten.</typeparam>
    /// <typeparam name="TKey">Der Typ der als Schlüssel genutzten Daten.</typeparam>
    /// <param name="values">Die Werte, aus denen der Baum erzeugt werden soll.</param>
    /// <param name="keyFn">Eine Funktion zu Ermitteln des Schlüssels einer Entität.</param>
    /// <param name="parentKeyFn">Eine Funktion zum Ermitteln des Schlüssels des übergeordneten Datensatzes.</param>
    /// <returns>Die Wurzel des erzeugten Baumes.</returns>
    public static IBidirectionalTree<T> ToTree<T, TKey>(this IEnumerable<T> values, Func<T, TKey> keyFn, Func<T, TKey> parentKeyFn)
        where TKey : notnull
    {
        var dict = values.ToDictionary(keyFn, v => (new BasicBidirectionalTree<T>(v), parentKeyFn(v)));

        foreach (var (value, parentKey) in dict.Values)
        {
            if (dict.TryGetValue(parentKey, out var parentNode))
            {
                parentNode.Item1.AddChild(value);
            }
        }

        return dict.Select(p => p.Value.Item1.Parent).Single(v => v != null)!;
    }
}
