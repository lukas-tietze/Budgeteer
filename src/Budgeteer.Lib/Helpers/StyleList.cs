// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="StyleList.cs" company="Lukas Tietze">
// Copyright (c) Lukas Tietze. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------------------------------

namespace Budgeteer.Lib.Helpers;

using System.Diagnostics.Contracts;

/// <summary>
/// Stellt eine Liste von inline-Stilen dar, die dynamisch aufgebaut werden kann.
/// </summary>
public readonly struct StyleList
{
    /// <summary>
    /// Die gesammelten Stile.
    /// </summary>
    private readonly string styles;

    /// <summary>
    /// Initialisiert eine neue Instanz der <see cref="StyleList"/> Struktur.
    /// </summary>
    /// <param name="styles">Die Sammlung der initialen Stile.</param>
    public StyleList(string? styles = null)
    {
        this.styles = styles ?? string.Empty;

        if (!string.IsNullOrEmpty(this.styles) && !this.styles.EndsWith(';'))
        {
            this.styles += ';';
        }
    }

    /// <summary>
    /// Ermöglicht den impliziten Aufruf von <see cref="ToString"/>.
    /// </summary>
    /// <param name="styleList">Der zu konvertierende Wert.</param>
    [Pure]
    public static implicit operator string(StyleList styleList) => styleList.ToString();

    /// <summary>
    /// Fügt den Stil für die Eigenschaft <paramref name="propertyName"/> mit dem Wert <paramref name="value"/> zur Liste hinzu.
    /// </summary>
    /// <typeparam name="T">Der Typ des Wertes des inline-Stils.</typeparam>
    /// <param name="propertyName">Der Name der Eigenschaft.</param>
    /// <param name="value">Der Wert der Eigenschaft.</param>
    /// <returns>Eine Kopie der aktuellen Instanz, mit den neuen Klassennamen.</returns>
    [Pure]
    public StyleList Add<T>(string propertyName, T value) => new($"{this.styles}{propertyName}:{value};");

    /// <summary>
    /// Gibt einen String zurück, der die Liste der gesammelten CSS-Klassen
    /// enthält oder null, falls die Liste leer ist.
    /// Wird null zurückgegeben, wird das class-Attribut gar nicht gerendert.
    /// </summary>
    /// <returns>Die Klassen-Liste oder null, wenn die Liste leer ist.</returns>
    [Pure]
    public string? ToAttributeString() => string.IsNullOrWhiteSpace(this.styles) ? null : this.styles.Trim();

    /// <inheritdoc/>
    [Pure]
    public override string ToString() => string.IsNullOrWhiteSpace(this.styles) ? string.Empty : this.styles.Trim();
}
