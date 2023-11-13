// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="IHtmlContentExtensions.cs" company="Lukas Tietze">
// Copyright (c) Lukas Tietze. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------------------------------

namespace Budgeteer.Lib.Taghelpers;

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Encodings.Web;

using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

/// <summary>
/// Stellt Erweiterungsmethoden für <see cref="IHtmlContent"/>
/// und für die Konvertierung in <see cref="IHtmlContent"/> bereit.
/// </summary>
public static class IHtmlContentExtensions
{
    /// <summary>
    /// Verknüpft zwei oder mehr <see cref="IHtmlContent"/>-Ojekte und gibt einen <see cref="IHtmlContent"/>
    /// zurück, der alle gegebenen Elemente auf derselben Ebene und in der gegebenen Reihenfolge ausgibt.
    /// </summary>
    /// <param name="content">Der erste einzufügende Inhalt.</param>
    /// <param name="firstOther">Der erste anzuhänge Inhalt.</param>
    /// <param name="moreOthers">Eine Liste beliebig vieler weiterer anzuhängender Inhalte.</param>
    /// <returns>Den erzeugten Html-Inhalt.</returns>
    public static IHtmlContent Concat(this IHtmlContent content, IHtmlContent firstOther, params IHtmlContent[] moreOthers) =>
        new HtmlContentCollection(moreOthers.Prepend(firstOther).Prepend(content));

    /// <summary>
    /// Erzeugt einen String aus <see cref="IHtmlContent"/>.
    /// Zum Debugging gedacht.
    /// </summary>
    /// <param name="html">Der auszulesende HTML-Inhalt.</param>
    /// <returns>Den HTML-Inhalt als String.</returns>
    public static string Dump(this IHtmlContent html)
    {
        var writer = new StringWriter();

        html.WriteTo(writer, HtmlEncoder.Default);

        return writer.ToString();
    }

    /// <summary>
    /// Erzeugt HTML-Inhalt aus einem String.
    /// Bei der Ausgabe werden Sonderzeichen entsprechend escaped.
    /// </summary>
    /// <param name="text">Der auszugebende Text.</param>
    /// <param name="escape">Gibt an, ob der Text beim Ausgeben escaped werden soll oder nicht.</param>
    /// <returns>Den erzeugten Html-Inhalt.</returns>
    public static IHtmlContent ToHTmlContent(this string text, bool escape = true) =>
        escape ? new StringHtmlContent(text) : new RawHtmlContent(text);

    /// <summary>
    /// Ermöglicht die Zusammenfassung einer Aufzählung von HTML-Inhalten in ein
    /// einziges Objekt, das <see cref="IHtmlContent"/> implementiert.
    /// Bei der Ausgabe werden alle gegebenen Inhalte auf derselben Ebene und
    /// in der gegebenen Reihenfolge ausgegeben.
    /// </summary>
    /// <param name="content">Die Aufzählung der auszugebenden HTML-Inhalte.</param>
    /// <returns>Den erzeugten Html-Inhalt.</returns>
    public static IHtmlContent ToHTmlContent(this IEnumerable<IHtmlContent> content) => new HtmlContentCollection(content);
}
