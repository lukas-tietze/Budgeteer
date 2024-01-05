// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="RenderedTagHelperBase.cs" company="Lukas Tietze">
// Copyright (c) Lukas Tietze. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------------------------------

namespace Budgeteer.Lib.Taghelpers;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Budgeteer.Lib.Helpers;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;

/// <summary>
/// Stellt eine Basisklasse zur Abstraktion vom normalen Tag-Helper-Konzept dar,
/// die den Aufruf von Tag-Helpern aus anderen Tag-Helper heraus vereinfacht.
///
/// Diese Basisklasse implementiert die Methode <see cref="RenderAsync"/>,
/// die die eigentliche Aufgabe das Erzeugens des HTML-Inhalts übernimmt.
/// In <see cref="ProcessAsync(TagHelperContext, TagHelperOutput)"/>
/// wird diese Methode aufgerufen und der gesamte Inhalt des Tag-Helpers wird mit
/// dem Ergebnis von <see cref="RenderAsync"/> ersetzt.
/// </summary>
public abstract class RenderedTagHelperBase : TagHelper
{
    /// <summary>
    /// Die Auflistung aller Attribute, die beim Ausführen des Tag-Helpers übergeben wurden.
    /// </summary>
    private IReadOnlyCollection<TagHelperAttribute> attributes;

    /// <summary>
    /// Die Liste der Klassen, die auf dem HTML-Tag des Tag-Helper angegeben sind.
    /// </summary>
    private ClassList classes;

    /// <summary>
    /// Der Tag-Name des aktiven Tag-Helpers.
    /// </summary>
    private string tagName;

    /// <summary>
    /// Initialisiert eine neue Instanz der <see cref="RenderedTagHelperBase"/> Klasse.
    /// </summary>
    public RenderedTagHelperBase()
    {
        this.tagName = string.Empty;
        this.attributes = Array.Empty<TagHelperAttribute>();
    }

    /// <summary>
    /// Holt die Auflistung aller Attribute.
    /// </summary>
    public IReadOnlyCollection<TagHelperAttribute> Attributes
    {
        get => this.attributes;
        init => this.attributes = value;
    }

    /// <summary>
    /// Holt die Liste der Klassen, die auf dem HTML-Tag des Tag-Helper angegeben sind.
    /// </summary>
    public ClassList Classes
    {
        get => this.classes;
        init => this.classes = value;
    }

    /// <summary>
    /// Holt den Tag-Namen des aktiven Tag-Helpers.
    /// </summary>
    public string TagName
    {
        get => this.tagName;
        init => this.tagName = value;
    }

    /// <inheritdoc/>
    public async override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        this.classes = context.AllAttributes.GetClassList();
        this.tagName = context.TagName;
        this.attributes = context.AllAttributes;

        var childContent = await output.GetChildContentAsync();
        var ownContent = await this.RenderAsync(childContent.IsEmptyOrWhiteSpace ? null : childContent);

        if (ownContent is EmptyHtmlContent)
        {
            output.SuppressOutput();
        }
        else
        {
            output.TagName = string.Empty;
            output.Content.SetHtmlContent(ownContent);
        }
    }

    /// <summary>
    /// Wird in ableitenden Klassen überschrieben, um den HTML-Inhalt zu erzeugen,
    /// der anstelle des Tag-Helpers ausgegeben wird.
    ///
    /// Ableitende Klassen können <see cref="NoContent"/> zurückgeben, um jegliche Ausgabe zu unterbinden.
    /// </summary>
    /// <param name="content">Der im Tag-Helper enthaltene HTML-Inhalt.</param>
    /// <returns>Eine <see cref="Task{TResult}"/>-Instanz, die die asynchrone Bearbeitung der Methode darstellt und
    /// deren Ergebnis der gerenderte HTML-Inhalt ist.</returns>
    public abstract Task<IHtmlContent> RenderAsync(IHtmlContent? content = null);

    /// <summary>
    /// Holt ein Platzhalter-Objekt, dass einen leeren HTML-Inhalt darstellt.
    /// Kann in <see cref="RenderAsync(IHtmlContent)"/> zurückgegeben werden, um
    /// die Ausgabe zu unterbinden.
    /// </summary>
    /// <returns>Einen leeren HTML-Inhalt.</returns>
    protected static IHtmlContent NoContent() => default(EmptyHtmlContent);
}
