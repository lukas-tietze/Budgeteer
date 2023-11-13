// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="UrlQueryBuilder.cs" company="Lukas Tietze">
// Copyright (c) Lukas Tietze. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------------------------------

namespace Budgeteer.Lib.Helpers;

using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

/// <summary>
/// Hilfsklasse zum Kodieren und Kombinieren mehrerer Teile eines URL-Query.
/// </summary>
public readonly struct UrlQueryBuilder
{
    /// <summary>
    /// Enthält die Basis-URL der Anwendung.
    /// </summary>
    private readonly string? query;

    /// <summary>
    /// Initialisiert eine neue Instanz der <see cref="UrlQueryBuilder"/> Struktur.
    /// </summary>
    /// <param name="query">Der initiale Query.</param>
    private UrlQueryBuilder(string query)
    {
        this.query = query;
    }

    /// <summary>
    /// Ermöglicht die implizite Konvertierung einer <see cref="UrlQueryBuilder"/>-Instanz
    /// in einen String, wobei das Ergebnis <see cref="ToString"/> ist.
    /// </summary>
    /// <param name="builder">Die zu konvertierende Instanz.</param>
    [Pure]
    public static implicit operator string(UrlQueryBuilder builder) => builder.ToString();

    /// <summary>
    /// Ermöglicht die implizite Konvertierung eines Strings in
    /// eine <see cref="UrlQueryBuilder"/>-Instanz.
    /// </summary>
    /// <param name="str">Der zu konvertierende String.</param>
    [Pure]
    public static implicit operator UrlQueryBuilder(string str) => new(str);

    /// <summary>
    /// Fügt eine Attribut zum Query hinzu.
    /// </summary>
    /// <param name="name">Der Name des hinzuzufügenden Attributs.</param>
    /// <param name="value">Der Wert des hinzuzufügenden Attributs.</param>
    /// <returns>Eine Referenz auf die aktuelle Instanz, um Method-Chaining zu ermöglichen.</returns>
    [Pure]
    public UrlQueryBuilder Add(string name, string value) =>
        (string.IsNullOrEmpty(this.query) ? string.Empty : this.query + '&') +
        Uri.UnescapeDataString(name) + '=' + Uri.UnescapeDataString(value);

    /// <summary>
    /// Fügt eine Attribut mit mehreren Werten zum Query hinzu.
    /// </summary>
    /// <param name="name">Der Name des hinzuzufügenden Attributs.</param>
    /// <param name="values">Die Werte des hinzuzufügenden Attributs.</param>
    /// <returns>Eine Referenz auf die aktuelle Instanz, um Method-Chaining zu ermöglichen.</returns>
    [Pure]
    public UrlQueryBuilder Add(string name, params string[] values) => this.Add(name, values.AsEnumerable());

    /// <summary>
    /// Fügt eine Attribut mit mehreren Werten zum Query hinzu.
    /// </summary>
    /// <param name="name">Der Name des hinzuzufügenden Attributs.</param>
    /// <param name="values">Die Werte des hinzuzufügenden Attributs.</param>
    /// <returns>Eine Referenz auf die aktuelle Instanz, um Method-Chaining zu ermöglichen.</returns>
    [Pure]
    public UrlQueryBuilder Add(string name, IEnumerable<string> values) => values.Aggregate(this, (me, value) => me.Add(name, value));

    /// <summary>
    /// Erzeugt eine String-Repräsentation der aktuellen Instanz.
    /// </summary>
    /// <returns>Einen String, der aktuelle Instanz darstellt.</returns>
    [Pure]
    public override string ToString() => this.query ?? string.Empty;
}
