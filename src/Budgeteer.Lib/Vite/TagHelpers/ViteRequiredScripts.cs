// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="ViteRequiredScripts.cs" company="Lukas Tietze">
// Copyright (c) Lukas Tietze. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------------------------------

namespace Budgeteer.Lib.Vite.TagHelpers;

using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Stellt eine Liste angeforderter Skripte dar, für
/// die ein &lt;script&gt;-Tag und ggf. ein preload-Link
/// erzeugt werden sollen.
/// </summary>
internal class ViteRequiredScripts : IEnumerable<string>
{
    /// <summary>
    /// Die interne Liste der angeforderten Skripte.
    /// </summary>
    private readonly List<string> items = new();

    /// <inheritdoc/>
    public IEnumerator<string> GetEnumerator() => ((IEnumerable<string>)this.items).GetEnumerator();

    /// <inheritdoc/>
    IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)this.items).GetEnumerator();

    /// <summary>
    /// Fügt ein weiteres Skript hinzu.
    /// </summary>
    /// <param name="item">Das hinzuzufügende Element.</param>
    internal void Add(string item) => this.items.Add(item);
}
