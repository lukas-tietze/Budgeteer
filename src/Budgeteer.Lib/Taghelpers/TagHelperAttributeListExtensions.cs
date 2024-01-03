// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="TagHelperAttributeListExtensions.cs" company="Lukas Tietze">
// Copyright (c) Lukas Tietze. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------------------------------

namespace Budgeteer.Lib.Taghelpers;

using Microsoft.AspNetCore.Razor.TagHelpers;

/// <summary>
/// Enthält Erweiterungen für <see cref="TagHelperAttributeList"/>.
/// </summary>
public static class TagHelperAttributeListExtensions
{
    /// <summary>
    /// Fügt einen Wert zu einem bereits vorhandenen Attribut hinzu oder legt
    /// ein neues Attribut mit dem gegebenen Wert an.
    /// Kann z.B. genutzt werden, um eine neue CSS-Klasse zur Ausgabe hinzuzufügen.
    /// Falls bereits ein Attribut mit dem Namen <paramref name="attributeName"/>
    /// vorhanden ist, wird zuerst <paramref name="separator"/> und dann <paramref name="value"/>
    /// hinzugefügt und der Eintrag in der Liste wird ersetzt.
    ///
    /// Falls <paramref name="separator"/> nicht gegeben ist, wird ein Trenner bestimmt.
    /// Das ist ein Semikolon, falls <paramref name="attributeName"/> "style" ist und sonst ein Leerzeichen.
    /// </summary>
    /// <param name="tagHelperAttributes">Die Instanz auf der die Operation ausgeführt werden soll.</param>
    /// <param name="attributeName">Der Name des Attributs, das erweitert werden soll.</param>
    /// <param name="value">Der anzuhängende Wert.</param>
    /// <param name="separator">Der String, der zwischen dem alten und neuen Wert eingefügt werden soll.</param>
    /// <returns><paramref name="tagHelperAttributes"/>, um Method-Chaining zu ermöglichen.</returns>
    public static TagHelperAttributeList AppendAttribute(this TagHelperAttributeList tagHelperAttributes, string attributeName, string value, string? separator = null)
    {
        if (tagHelperAttributes.TryGetAttribute(attributeName, out var attribute))
        {
            separator ??= attributeName switch
            {
                "style" => ";",
                _ => " ",
            };

            tagHelperAttributes.SetAttribute(attributeName, attribute.Value.ToString() + separator + value);
        }
        else
        {
            attribute = new TagHelperAttribute(attributeName, value);

            tagHelperAttributes.Add(attribute);
        }

        return tagHelperAttributes;
    }
}
