// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="HtmlContentCollection.cs" company="Lukas Tietze">
// Copyright (c) Lukas Tietze. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------------------------------

namespace Budgeteer.Lib.Taghelpers;

using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.Encodings.Web;

using Microsoft.AspNetCore.Html;

/// <summary>
/// Eine Implementierung von <see cref="IHtmlContent"/>, die aus einer Liste
/// anderer Inhalte besteht und selbst keinen weiteren Inhalt hinzufügt.
/// </summary>
public class HtmlContentCollection : IHtmlContent, IEnumerable<IHtmlContent>
{
    /// <summary>
    /// Die zu rendernden Inhalte.
    /// </summary>
    private readonly List<IHtmlContent> contents;

    /// <summary>
    /// Initialisiert eine neue Instanz der <see cref="HtmlContentCollection"/> Klasse.
    /// </summary>
    /// <param name="content">Der initiale Inhalt.</param>
    public HtmlContentCollection(IEnumerable<IHtmlContent> content)
    {
        this.contents = new List<IHtmlContent>(content);
    }

    /// <summary>
    /// Initialisiert eine neue Instanz der <see cref="HtmlContentCollection"/> Klasse.
    /// </summary>
    public HtmlContentCollection()
    {
        this.contents = [];
    }

    /// <summary>
    /// Fügt weiteren HTML-Inhalt hinzu.
    /// </summary>
    /// <param name="content">Der hinzuzufügende Inhalt.</param>
    /// <returns>Eine Referenz auf die aktuelle Instanz.</returns>
    public HtmlContentCollection Add(IHtmlContent content)
    {
        this.contents.Add(content);

        return this;
    }

    /// <inheritdoc/>
    public IEnumerator<IHtmlContent> GetEnumerator() => ((IEnumerable<IHtmlContent>)this.contents).GetEnumerator();

    /// <inheritdoc/>
    IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)this.contents).GetEnumerator();

    /// <inheritdoc/>
    public void WriteTo(TextWriter writer, HtmlEncoder encoder)
    {
        foreach (var content in this.contents)
        {
            content.WriteTo(writer, encoder);
        }
    }
}
