// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="UrlPathBuilder.cs" company="Lukas Tietze">
// Copyright (c) Lukas Tietze. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------------------------------

namespace Budgeteer.Lib.Helpers;

using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

/// <summary>
/// Hilfsklasse zum Kodieren und Kombinieren mehrerer Teile des Pfades einer URL.
/// </summary>
public readonly struct UrlPathBuilder
{
    /// <summary>
    /// Enthält die Basis-URL der Anwendung.
    /// </summary>
    private readonly string? url;

    /// <summary>
    /// Initialisiert eine neue Instanz der <see cref="UrlPathBuilder"/> Struktur.
    /// </summary>
    /// <param name="url">Die initiale URL.</param>
    public UrlPathBuilder(string url)
    {
        this.url = url.TrimEnd('/');
    }

    /// <summary>
    /// Ermöglicht die implizite Konvertierung einer <see cref="UrlPathBuilder"/>-Instanz
    /// in einen String, wobei das Ergebnis <see cref="ToString"/> ist.
    /// </summary>
    /// <param name="builder">Die zu konvertierende Instanz.</param>
    [Pure]
    public static implicit operator string(UrlPathBuilder builder) => builder.ToString();

    /// <summary>
    /// Ermöglicht die implizite Konvertierung eines Strings in eine <see cref="UrlPathBuilder"/>-Instanz.
    /// </summary>
    /// <param name="str">Der zu konvertierende String.</param>
    [Pure]
    public static implicit operator UrlPathBuilder(string str) => new(str);

    /// <summary>
    /// Fügt einen Abschnitt zur erzeugten URL hinzu.
    /// </summary>
    /// <param name="part">Der hinzuzufügende Abschnitt.</param>
    /// <returns>Eine Referenz auf die aktuelle Instanz, um Method-Chaining zu ermöglichen.</returns>
    [Pure]
    public UrlPathBuilder Add(string part) => this.Append(Uri.EscapeDataString(part));

    /// <summary>
    /// Fügt mehrere Abschnitte zur erzeugten URL hinzu.
    /// </summary>
    /// <param name="parts">Die hinzuzufügenden Abschnitte.</param>
    /// <returns>Eine Referenz auf die aktuelle Instanz, um Method-Chaining zu ermöglichen.</returns>
    [Pure]
    public UrlPathBuilder Add(params string[] parts) => this.Add(parts.AsEnumerable());

    /// <summary>
    /// Fügt mehrere Abschnitte zur erzeugten URL hinzu.
    /// </summary>
    /// <param name="parts">Die hinzuzufügenden Abschnitte.</param>
    /// <returns>Eine Referenz auf die aktuelle Instanz, um Method-Chaining zu ermöglichen.</returns>
    [Pure]
    public UrlPathBuilder Add(IEnumerable<string> parts) => parts.Aggregate(this, (me, part) => me.Add(part));

    /// <summary>
    /// Fügt mehrere Daten-Abschnitte zur erzeugten URL hinzu.
    /// </summary>
    /// <param name="part">Der hinzuzufügende Daten-Abschnitt.</param>
    /// <returns>Eine Referenz auf die aktuelle Instanz, um Method-Chaining zu ermöglichen.</returns>
    [Pure]
    public UrlPathBuilder AddData(string part) => this.Append(Uri.EscapeDataString(part));

    /// <summary>
    /// Fügt mehrere Daten-Abschnitte zur erzeugten URL hinzu.
    /// </summary>
    /// <param name="parts">Die hinzuzufügenden Daten-Abschnitte.</param>
    /// <returns>Eine Referenz auf die aktuelle Instanz, um Method-Chaining zu ermöglichen.</returns>
    [Pure]
    public UrlPathBuilder AddData(params string[] parts) => this.AddData(parts.AsEnumerable());

    /// <summary>
    /// Fügt mehrere Daten-Abschnitte zur erzeugten URL hinzu.
    /// </summary>
    /// <param name="parts">Die hinzuzufügenden Daten-Abschnitte.</param>
    /// <returns>Eine Referenz auf die aktuelle Instanz, um Method-Chaining zu ermöglichen.</returns>
    [Pure]
    public UrlPathBuilder AddData(IEnumerable<string> parts) => parts.Aggregate(this, (me, part) => me.AddData(part));

    /// <summary>
    /// Erzeugt eine String-Repräsentation der aktuellen Instanz.
    /// </summary>
    /// <returns>Einen String, der aktuelle Instanz darstellt.</returns>
    [Pure]
    public override string ToString() => this.url ?? string.Empty;

    /// <summary>
    /// Fügt einen neuen Teil zur URL hinzu.
    /// </summary>
    /// <param name="part">Der hinzuzufügende Abschnitt.</param>
    /// <returns>Eine Referenz auf die aktuelle Instanz, um Method-Chaining zu ermöglichen.</returns>
    private UrlPathBuilder Append(string part) => (this.url ?? string.Empty) + '/' + part.Trim('/');
}
