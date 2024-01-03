// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="EmptyHtmlContent.cs" company="Lukas Tietze">
// Copyright (c) Lukas Tietze. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------------------------------

namespace Budgeteer.Lib.Taghelpers;

using System.IO;
using System.Text.Encodings.Web;

using Microsoft.AspNetCore.Html;

/// <summary>
/// Stellt einen leeren <see cref="IHtmlContent"/> dar.
/// </summary>
internal readonly struct EmptyHtmlContent : IHtmlContent
{
    /// <inheritdoc/>
    public readonly void WriteTo(TextWriter writer, HtmlEncoder encoder)
    {
    }
}
