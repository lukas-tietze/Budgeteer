// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="ClassList.cs" company="Lukas Tietze">
// Copyright (c) Lukas Tietze. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------------------------------

namespace Budgeteer.Lib.Helpers;

using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

/// <summary>
/// Stellt eine Liste von CSS-Klassen dar, die dynamisch aufgebaut werden kann.
/// </summary>
public readonly struct ClassList
{
    /// <summary>
    /// Die gesammelten Klassen.
    /// </summary>
    private readonly string? classes;

    /// <summary>
    /// Initialisiert eine neue Instanz der <see cref="ClassList"/> Struktur.
    /// </summary>
    /// <param name="classes">Die Sammlung der initialen Klassennamen.</param>
    public ClassList(string? classes = null)
    {
        this.classes = classes;
    }

    /// <summary>
    /// Holt einen WErt, der angibt, ob die Klassenliste leer ist oder nicht.
    /// </summary>
    [Pure]
    public bool Empty => string.IsNullOrWhiteSpace(this.classes);

    /// <summary>
    /// Ermöglicht den impliziten Aufruf von <see cref="ClassList(string?)"/>.
    /// </summary>
    /// <param name="str">Der zu konvertierende Wert.</param>
    [Pure]
    public static implicit operator ClassList(string str) => new(str);

    /// <summary>
    /// Ermöglicht den impliziten Aufruf von <see cref="ToString"/>.
    /// </summary>
    /// <param name="classList">Der zu konvertierende Wert.</param>
    [Pure]
    public static implicit operator string(ClassList classList) => classList.ToString();

    /// <summary>
    /// Überladung für den Additions-Operator, als Abkürzung für <see cref="Add(string?)"/>.
    /// </summary>
    /// <param name="classList">Die zu erweiternde <see cref="ClassList"/>-Instanz.</param>
    /// <param name="str">Der String mit der Liste hinzuzufügender Klassen.</param>
    /// <returns>Die erweiterte Klassenliste.</returns>
    [Pure]
    public static ClassList operator +(ClassList classList, string str) => classList.Add(str);

    /// <summary>
    /// Fügt die gegebene CSS-Klasse zur Liste hinzu.
    /// </summary>
    /// <param name="className">Die hinzuzufügende CSS-Klasse.</param>
    /// <returns>Eine Kopie der aktuellen Instanz, mit den neuen Klassennamen.</returns>
    [Pure]
    public ClassList Add(string? className)
    {
        className = className?.Trim();

        return !string.IsNullOrEmpty(className) ? new ClassList(this.classes + ' ' + className) : this;
    }

    /// <summary>
    /// Fügt die gegebenen CSS-Klassen zur Liste hinzu.
    /// </summary>
    /// <param name="classNames">Die hinzuzufügenden CSS-Klassen.</param>
    /// <returns>Eine Kopie der aktuellen Instanz, mit den neuen Klassennamen.</returns>
    [Pure]
    public ClassList Add(IEnumerable<string?> classNames)
    {
        var res = this;

        foreach (var className in classNames)
        {
            res = res.Add(className);
        }

        return res;
    }

    /// <summary>
    /// Fügt die gegebenen CSS-Klassen zur Liste hinzu.
    /// </summary>
    /// <param name="classNames">Die hinzuzufügenden CSS-Klassen.</param>
    /// <returns>Eine Kopie der aktuellen Instanz, mit den neuen Klassennamen.</returns>
    [Pure]
    public ClassList Add(params string?[] classNames) =>
        this.Add(classNames.AsEnumerable());

    /// <summary>
    /// Fügt eine CSS-Klasse hinzu, wenn die Bedingung <paramref name="condition"/>
    /// true ist. Utility-Funktion, um im Template das if(...) zu sparen.
    /// </summary>
    /// <param name="condition">Die auszuwertende Bedingung.</param>
    /// <param name="className">Die hinzuzufügende CSS-Klasse.</param>
    /// <param name="elseClassName">Der Klassenname, der hinzugefügt werden soll, wenn die Bedingung falsch ist.</param>
    /// <returns>Eine Kopie der aktuellen Instanz, mit den neuen Klassennamen.</returns>
    [Pure]
    public ClassList AddIf(bool condition, string? className, string? elseClassName = null) =>
        condition ? this.Add(className) : this.Add(elseClassName);

    /// <summary>
    /// Fügt die CSS-Klassen hinzu, bei denen die gegebene Bedingung
    /// true ist. Utility-Funktion, um im Template das if(...) zu sparen.
    /// </summary>
    /// <param name="classNames">Die Tupel aus Bedingung und hinzuzufügender CSS-Klasse.</param>
    /// <returns>Eine Kopie der aktuellen Instanz, mit den neuen Klassennamen.</returns>
    [Pure]
    public ClassList AddIf(IEnumerable<(bool Condition, string? ClassName)> classNames) =>
        this.Add(classNames.Where(c => c.Condition).Select(c => c.ClassName));

    /// <summary>
    /// Fügt die CSS-Klassen hinzu, bei denen die gegebene Bedingung
    /// true ist. Utility-Funktion, um im Template das if(...) zu sparen.
    /// </summary>
    /// <param name="classNames">Die Tupel aus Bedingung und hinzuzufügender CSS-Klasse.</param>
    /// <returns>Eine Kopie der aktuellen Instanz, mit den neuen Klassennamen.</returns>
    [Pure]
    public ClassList AddIf(params (bool Condition, string? ClassName)[] classNames) =>
        this.AddIf(classNames.AsEnumerable());

    /// <summary>
    /// Gibt einen String zurück, der die Liste der gesammelten CSS-Klassen
    /// enthält oder null, falls die Liste leer ist.
    /// Wird null zurückgegeben, wird das class-Attribut gar nicht gerendert.
    /// </summary>
    /// <returns>Die Klassen-Liste oder null, wenn die Liste leer ist.</returns>
    [Pure]
    public string? ToAttributeString() => string.IsNullOrWhiteSpace(this.classes) ? null : this.classes.Trim();

    /// <inheritdoc/>
    [Pure]
    public override string ToString() => string.IsNullOrWhiteSpace(this.classes) ? string.Empty : this.classes.Trim();
}
