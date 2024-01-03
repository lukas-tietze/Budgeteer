// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="RawHtmlContent.cs" company="Lukas Tietze">
// Copyright (c) Lukas Tietze. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------------------------------

namespace Budgeteer.Lib.Taghelpers;

using System.IO;
using System.Text.Encodings.Web;

using Microsoft.AspNetCore.Html;

/// <summary>
/// Stellt einen uncodierten <see cref="IHtmlContent"/> dar.
/// </summary>
internal readonly struct RawHtmlContent : IHtmlContent
{
    /// <summary>
    /// Der HTML-String, der in <see cref="WriteTo(TextWriter, HtmlEncoder)"/>
    /// uncodiert ausgegeben wird.
    /// </summary>
    private readonly string trustedContent;

    /// <summary>
    /// Initialisiert eine neue Instanz der <see cref="RawHtmlContent"/> Struktur.
    /// </summary>
    /// <param name="trustedContent">
    /// Der HTML-String, der in <see cref="WriteTo(TextWriter, HtmlEncoder)"/>
    /// uncodiert ausgegeben wird.
    /// </param>
    public RawHtmlContent(string trustedContent)
    {
        this.trustedContent = trustedContent;
    }

    /// <inheritdoc/>
    public readonly void WriteTo(TextWriter writer, HtmlEncoder encoder) => writer.Write(this.trustedContent);
}
