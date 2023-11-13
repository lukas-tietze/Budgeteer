// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="RenderedSyncTagHelperBase.cs" company="Lukas Tietze">
// Copyright (c) Lukas Tietze. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------------------------------

namespace Budgeteer.Lib.Taghelpers;

using System.Threading.Tasks;

using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;

/// <summary>
/// Stellt eine Erweiterung von <see cref="TagHelper"/> dar, die ein
/// synchrones Rendering unterstützt.
/// </summary>
public abstract class RenderedSyncTagHelperBase : RenderedTagHelperBase
{
    /// <summary>
    /// Wird in ableitenden Klassen überschrieben, um den HTML-Inhalt zu erzeugen,
    /// der anstelle des Tag-Helpers ausgegeben wird.
    ///
    /// Ableitende Klassen können <see cref="RenderedTagHelperBase.NoContent"/> zurückgeben, um jegliche Ausgabe zu unterbinden.
    /// </summary>
    /// <param name="content">Der im Tag-Helper enthaltene HTML-Inhalt.</param>
    /// <returns>Eine <see cref="Task{TResult}"/>-Instanz, die die asynchrone Bearbeitung der Methode darstellt und
    /// deren Ergebnis der gerenderte HTML-Inhalt ist.</returns>
    public override Task<IHtmlContent> RenderAsync(IHtmlContent? content = null) => Task.FromResult(this.Render(content));

    /// <summary>
    /// Wird in ableitenden Klassen überschrieben, um den HTML-Inhalt zu erzeugen,
    /// der anstelle des Tag-Helpers ausgegeben wird.
    ///
    /// Ableitende Klassen können <see cref="RenderedTagHelperBase.NoContent"/> zurückgeben, um jegliche Ausgabe zu unterbinden.
    /// </summary>
    /// <param name="content">Der im Tag-Helper enthaltene HTML-Inhalt.</param>
    /// <returns>Den gerenderten HTML-Inhalt.</returns>
    public abstract IHtmlContent Render(IHtmlContent? content = null);
}
