// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="ReadOnlyTagHelperAttributeListExtensions.cs" company="Lukas Tietze">
// Copyright (c) Lukas Tietze. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------------------------------

namespace Budgeteer.Lib.Taghelpers;

using Budgeteer.Lib.Helpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

/// <summary>
/// Stellt Erweiterungsmethoden für <see cref="ReadOnlyTagHelperAttributeList"/> bereit.
/// </summary>
public static class ReadOnlyTagHelperAttributeListExtensions
{
    /// <summary>
    /// Ruft den Wert des class-Attributs als String ab.
    /// Falls in der gegebenen Liste noch kein class-Attribut vorhanden ist, wird
    /// ein leerer String zurückgegeben.
    /// </summary>
    /// <param name="attributeList">Die Liste der Attribute aus der das class-Attribut gelesen werden soll.</param>
    /// <returns>Den Wert des class-Attributs oder einen leeren String.</returns>
    public static ClassList GetClassList(this ReadOnlyTagHelperAttributeList attributeList) => new(attributeList.GetAttributeStringValue("class"));

    /// <summary>
    /// Ruft den Wert des style-Attributs als String ab.
    /// Falls in der gegebenen Liste noch kein style-Attribut vorhanden ist, wird
    /// ein leerer String zurückgegeben.
    /// </summary>
    /// <param name="attributeList">Die Liste der Attribute aus der das style-Attribut gelesen werden soll.</param>
    /// <returns>Den Wert des style-Attributs oder einen leeren String.</returns>
    public static StyleList GetStyleList(this ReadOnlyTagHelperAttributeList attributeList) => new(attributeList.GetAttributeStringValue("style"));

    /// <summary>
    /// Ruft den Wert des Attributs mit dem Namen <paramref name="attributeName"/> als String ab.
    /// Falls in der gegebenen Liste noch kein Attribut mit diesem Namen vorhanden ist, wird
    /// ein leerer String zurückgegeben.
    /// </summary>
    /// <param name="attributeList">Die Liste der Attribute aus der das Attribut gelesen werden soll.</param>
    /// <param name="attributeName">Der Namedes gesuchten Attributs.</param>
    /// <returns>Den Wert des gesuchten Attributs oder einen leeren String.</returns>
    public static string GetAttributeStringValue(this ReadOnlyTagHelperAttributeList attributeList, string attributeName) =>
        (attributeList.TryGetAttribute(attributeName, out var attributeValue) ? attributeValue : null)?.Value.ToString() ?? string.Empty;
}
