// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="FluentTagBuilder.cs" company="Lukas Tietze">
// Copyright (c) Lukas Tietze. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------------------------------

namespace Budgeteer.Lib.Taghelpers;

using System.Collections.Generic;
using System.IO;
using System.Text.Encodings.Web;

using Budgeteer.Lib.Helpers;

using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

/// <summary>
/// Ermöglicht die Erzeugung von HTML-Tags unter Verwendung eines Fluent-API.
/// </summary>
public class FluentTagBuilder : IHtmlContent
{
    /// <summary>
    /// Enthält den gekapselten <see cref="tagBuilder"/>.
    /// </summary>
    private readonly TagBuilder tagBuilder;

    /// <summary>
    /// Initialisiert eine neue Instanz der <see cref="FluentTagBuilder"/> Klasse.
    /// </summary>
    /// <param name="tagName">Der Name des HTML-Tags, der ertellt werden soll.</param>
    /// <param name="tagRenderMode">Der Modus zur Darstellung des Tags.</param>
    public FluentTagBuilder(string tagName, TagRenderMode? tagRenderMode = null)
    {
        this.tagBuilder = new TagBuilder(tagName);

        if (tagRenderMode.HasValue)
        {
            this.tagBuilder.TagRenderMode = tagRenderMode.Value;
        }
    }

    /// <summary>
    /// Ermöglicht die implizite Konvertierung einer <see cref="FluentTagBuilder"/>-Instanz
    /// in eine <see cref="TagBuilder"/>-Instanz. Dabei wird eine private Variable herausgegeben.
    /// </summary>
    /// <param name="immediateFluentTagBuilder">Die zu kovnertierende Instanz.</param>
    public static implicit operator TagBuilder(FluentTagBuilder immediateFluentTagBuilder) => immediateFluentTagBuilder.tagBuilder;

    /// <summary>
    /// Fügt eine oder mehrere Klassen zum Tag hinzu.
    /// </summary>
    /// <param name="classList">Die CSS-Klasse(n).</param>
    /// <returns>Eine Referenz auf die aktuelle Instanz.</returns>
    public FluentTagBuilder AddClass(string classList)
    {
        this.tagBuilder.AddCssClass(classList);

        return this;
    }

    /// <summary>
    /// Fügt einen weiteren inline-Stil hinzu.
    /// Der Wert wird an die ggf. bestehenden inline-Stile angehängt.
    /// </summary>
    /// <param name="property">Das CSS-Attribut, dessen Stil festgelegt werden soll.</param>
    /// <param name="value">Der Wert des CSS-Attribus.</param>
    /// <returns>Eine Referenz auf die aktuelle Instanz.</returns>
    public FluentTagBuilder AddStyle(string property, string value)
    {
        var styleList = new StyleList(this.tagBuilder.Attributes.GetValueOrDefault("style", string.Empty));

        return this.SetAttribute("style", styleList.Add(property, value), true);
    }

    /// <summary>
    /// Fügt bereits gerenderten HTML-Inhalt hinzu.
    /// </summary>
    /// <param name="content">Der darzustellende Inhalt.</param>
    /// <returns>Eine Referenz auf die aktuelle Instanz.</returns>
    public FluentTagBuilder Append(IHtmlContent content)
    {
        this.tagBuilder.InnerHtml.AppendHtml(content);

        return this;
    }

    /// <summary>
    /// Fügt bereits gerenderten HTML-Inhalt hinzu.
    /// </summary>
    /// <param name="contentList">Der darzustellende Inhalt.</param>
    /// <returns>Eine Referenz auf die aktuelle Instanz.</returns>
    public FluentTagBuilder Append(IEnumerable<IHtmlContent> contentList)
    {
        foreach (var content in contentList)
        {
            this.tagBuilder.InnerHtml.AppendHtml(content);
        }

        return this;
    }

    /// <summary>
    /// Fügt den gegebenen Text hinzu.
    /// </summary>
    /// <param name="text">Der hinzuzufügende Text.</param>
    /// <returns>Eine Referenz auf die aktuelle Instanz.</returns>
    public FluentTagBuilder Append(string text)
    {
        this.tagBuilder.InnerHtml.Append(text);

        return this;
    }

    /// <summary>
    /// Fügt HTML-Text zum Tags hinzu, ohne es zu escapen.
    /// </summary>
    /// <param name="html">Das hinzuzfügende HTML.</param>
    /// <returns>Eine Referenz auf die aktuelle Instanz.</returns>
    public IHtmlContent AppendHtml(string html)
    {
        this.tagBuilder.InnerHtml.AppendHtml(html);

        return this;
    }

    /// <summary>
    /// Fügt ein HTML-Attribut hinzu.
    /// Falls bereits ein gleichnamiges Attribut vorhanden ist, entscheidet
    /// <paramref name="overwrite"/>, ob dieses Attribut überschrieben wird,
    /// oder ob das neue Attribut verworfen wird.
    /// </summary>
    /// <param name="attr">Der Name des Attributs.</param>
    /// <param name="value">Der Wert des Attributs.</param>
    /// <param name="overwrite">Gibt an, ob ein ggf. bereits existierendes gleichnamiges Attribut überschrieben werden soll oder nicht.</param>
    /// <returns>Eine Referenz auf die aktuelle Instanz.</returns>
    public FluentTagBuilder SetAttribute(string attr, string value, bool overwrite = false)
    {
        this.tagBuilder.MergeAttribute(attr, value, overwrite);

        return this;
    }

    /// <summary>
    /// Fügt ein HTML-Attribut hinzu.
    /// Falls bereits ein gleichnamiges Attribut vorhanden ist, entscheidet
    /// <paramref name="overwrite"/>, ob dieses Attribut überschrieben wird,
    /// oder ob das neue Attribut verworfen wird.
    /// </summary>
    /// <param name="attribute">Das hinzuzufügende Attribut.</param>
    /// <param name="overwrite">Gibt an, ob ein ggf. bereits existierendes gleichnamiges Attribut überschrieben werden soll oder nicht.</param>
    /// <returns>Eine Referenz auf die aktuelle Instanz.</returns>
    public FluentTagBuilder SetAttribute(TagHelperAttribute attribute, bool overwrite = false) =>
        this.SetAttribute(attribute.Name, attribute.Value.ToString() ?? string.Empty, overwrite);

    /// <summary>
    /// Fügt mehrere Attribute zugleich hinzu.
    /// Durch <paramref name="overwrite"/> kann angegeben werden, ob
    /// bestehende Attribute überschrieben werden sollen oder nicht.
    /// Die Einstellung wird dann auf alle Attribute angewandt.
    /// </summary>
    /// <param name="attributes">Die Auflistung der Attribute.</param>
    /// <param name="overwrite">Gibt an, ob bestehende Attribute überschrieben werden sollen oder nicht.</param>
    /// <returns>Eine Referenz auf die aktuelle Instanz.</returns>
    public FluentTagBuilder SetAttributes(IEnumerable<TagHelperAttribute> attributes, bool overwrite = false)
    {
        foreach (var attribute in attributes)
        {
            this.SetAttribute(attribute, overwrite);
        }

        return this;
    }

    /// <summary>
    /// Setzt die ID des HTML-Elements, also das id-Attribut.
    /// </summary>
    /// <param name="id">Die ID.</param>
    /// <returns>Eine Referenz auf die aktuelle Instanz.</returns>
    public FluentTagBuilder SetId(string id) => this.SetAttribute("id", id, true);

    /// <summary>
    /// Setzt den Title des HTML-Elements, also das title-Attribut.
    /// </summary>
    /// <param name="title">Der Titel.</param>
    /// <returns>Eine Referenz auf die aktuelle Instanz.</returns>
    public FluentTagBuilder SetTitle(string title) => this.SetAttribute("title", title, true);

    /// <inheritdoc/>
    public void WriteTo(TextWriter writer, HtmlEncoder encoder) => ((IHtmlContent)this.tagBuilder).WriteTo(writer, encoder);
}
