// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="ITree{T}.cs" company="Lukas Tietze">
// Copyright (c) Lukas Tietze. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------------------------------

namespace Budgeteer.DataStructures.Tree;

using System.Collections.Generic;

/// <summary>
/// Implementierende Klassen stellen eine Baumstruktur dar.
/// </summary>
/// <typeparam name="T">Der Typ der Daten, die mit dem baum verknüpft sind.</typeparam>
public interface ITree<T>
{
    /// <summary>
    /// Holt die Anzahl der direkten Kindknoten.
    /// </summary>
    int ChildCount { get; }

    /// <summary>
    /// Holt eine Auflistung aller Kindknoten.
    /// </summary>
    IEnumerable<ITree<T>> Children { get; }

    /// <summary>
    /// Holt oder setzt die verknüpften Daten.
    /// </summary>
    T Data { get; set; }

    /// <summary>
    /// Holt die Anzahl aller untergeordneten Knoten.
    /// </summary>
    int DescendantCount { get; }

    /// <summary>
    /// Fügt den gegebenen Kindknoten hinzu.
    /// </summary>
    /// <param name="node">Der hinzuzufügende Knoten.</param>
    void AddChild(ITree<T> node);

    /// <summary>
    /// Fügt einen Kindknoten mit den gegebenen Daten hinzu.
    /// </summary>
    /// <param name="data">Die Daten des hinzuzufügenden Knotens.</param>
    void AddChild(T data);

    /// <summary>
    /// Entfernt alle Kinknoten deren Wert gleich <paramref name="data"/> ist.
    /// Zum Vergleich wird, falls gegeben, <paramref name="comparer"/> genutzt
    /// oder sont <see cref="EqualityComparer{T}.Default"/>.
    /// </summary>
    /// <param name="data">Die Daten, der zu entfernenden Kindknoten.</param>
    /// <param name="comparer">Der zu nutzende Vergleichsperator.</param>
    /// <returns>True, wenn der Knotne gefunden und entfernt wurde, false, wenn der Knoten kein Kind des aktuellen Knotens war.</returns>
    int RemoveAllChildren(T data, IEqualityComparer<T>? comparer = null);

    /// <summary>
    /// Entfernt den gegebenen Kinknoten.
    /// </summary>
    /// <param name="node">Der zu entfernende Knoten.</param>
    /// <returns>True, wenn der Knotne gefunden und entfernt wurde, false, wenn der Knoten kein Kind des aktuellen Knotens war.</returns>
    bool RemoveChild(ITree<T> node);

    /// <summary>
    /// Entfernt den ersten Kinknoten dessen Wert gleich <paramref name="data"/> ist.
    /// Zum Vergleich wird, falls gegeben, <paramref name="comparer"/> genutzt
    /// oder sont <see cref="EqualityComparer{T}.Default"/>.
    /// </summary>
    /// <param name="data">Die Daten, des zu entfernenden Kindknotens.</param>
    /// <param name="comparer">Der zu nutzende Vergleichsperator.</param>
    /// <returns>True, wenn der Knotne gefunden und entfernt wurde, false, wenn der Knoten kein Kind des aktuellen Knotens war.</returns>
    bool RemoveChild(T data, IEqualityComparer<T>? comparer = null);

    /// <summary>
    /// Entfernt alle Kindknoten.
    /// </summary>
    void TruncateChildren();
}
