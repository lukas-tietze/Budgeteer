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
public class BasicBidirectionalTree<T>(T data) : BasicTree<T> IBidirectionalTree<T>
{
    /// <summary>
    /// Die Liste der untergeordneten Knoten.
    /// </summary>
    private readonly List<BasicBidirectionalTree<T>> children = [];

    /// <inheritdoc/>
    public int ChildCount => this.children.Count;

    /// <inheritdoc/>
    public IEnumerable<BasicBidirectionalTree<T>> Children => this.children;

    /// <summary>
    /// Holt oder setzt die verknüpften Daten.
    /// </summary>
    public T Data { get; set; } = data;

    /// <summary>
    /// Holt die Anzahl aller untergeordneten Knoten.
    /// </summary>
    public int DescendantCount { get; private set; }

    /// <summary>
    /// Holt den übergeordneten Knoten.
    /// </summary>
    public BasicBidirectionalTree<T>? Parent { get; private set; }

    /// <inheritdoc/>
    public IEnumerable<BasicBidirectionalTree<T>> EnumerateDepthFirst()
    {
        var stack = new Stack<BasicBidirectionalTree<T>>();

        stack.Push(this);

        while (stack.TryPop(out var node))
        {
            yield return node;

            foreach (var child in node.children)
            {
                stack.Push(child);
            }
        }
    }

    /// <inheritdoc/>
    public void AddChild(BasicBidirectionalTree<T> node)
    {
        if (!this.children.Contains(node))
        {
            this.children.Add(node);
        }
    }

    /// <inheritdoc/>
    public void AddChild(T data) => this.AddChild(new BasicBidirectionalTree<T>(data));

    /// <inheritdoc/>
    public IEnumerable<BasicBidirectionalTree<T>> EnumerateBreadthFirst()
    {
        var queue = new Queue<BasicBidirectionalTree<T>>();

        queue.Enqueue(this);

        while (queue.TryDequeue(out var node))
        {
            yield return node;

            foreach (var child in node.children)
            {
                queue.Enqueue(child);
            }
        }
    }

    /// <inheritdoc/>
    public IEnumerable<T> EnumerateDataBreadthFirst()
    {
        var queue = new Queue<BasicBidirectionalTree<T>>();

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

    /// <inheritdoc/>
    public IEnumerable<T> EnumerateDataDepthFirst()
    {
        var stack = new Stack<BasicBidirectionalTree<T>>();

        stack.Push(this);

        while (stack.TryPop(out var node))
        {
            yield return node.Data;

            foreach (var child in node.children)
            {
                stack.Push(child);
            }
        }
    }

    /// <inheritdoc/>
    public IEnumerable<T> EnumerateDataHorizontal() => throw new NotImplementedException();

    /// <inheritdoc/>
    public IEnumerable<BasicBidirectionalTree<T>> EnumerateHorizontal() => throw new NotImplementedException();

    /// <inheritdoc/>
    public int RemoveAllChildren(T data, IEqualityComparer<T>? comparer = null)
    {
        comparer ??= EqualityComparer<T>.Default;

        var oldCount = this.children.Count;

        this.children.RemoveAll(c => comparer.Equals(c.Data, data));

        return oldCount - this.children.Count;
    }

    /// <inheritdoc/>
    public bool RemoveChild(BasicBidirectionalTree<T> node) => throw new NotImplementedException();

    /// <inheritdoc/>
    public bool RemoveChild(T data, IEqualityComparer<T>? comparer = null)
    {
        comparer ??= EqualityComparer<T>.Default;

        var index = this.children.FindIndex(c => comparer.Equals(c.Data, data));

        if (index > 0)
        {
            this.children.RemoveAt(index);

            return true;
        }

        return false;
    }

    /// <inheritdoc/>
    public void TruncateChildren() => this.children.Clear();
}
