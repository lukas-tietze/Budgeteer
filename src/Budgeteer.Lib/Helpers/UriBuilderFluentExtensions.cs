// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="UriBuilderFluentExtensions.cs" company="Lukas Tietze">
// Copyright (c) Lukas Tietze. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------------------------------

namespace Budgeteer.Lib.Helpers;

using System;

/// <summary>
/// Stellt ein Fluent-API für <see cref="UriBuilder"/> bereit.
/// </summary>
public static class UriBuilderFluentExtensions
{
    /// <summary>
    /// Fügt einen Datensatz an die URL an. Der String wird
    /// wie ein gewöhnlicher URL-Teil in <see cref="AddPathPart(UriBuilder, string)"/>
    /// behandelt, aber anders kodiert.
    /// </summary>
    /// <param name="me">Die Instanz, die geändert werden soll.</param>
    /// <param name="dataPart">Der Datensatz, der kodiert an die URL angehängt werden soll.</param>
    /// <returns>Eine Referenz auf die aktuelle Instanz, um Method-Chaining zu ermöglichen.</returns>
    public static UriBuilder AddPathDataPart(this UriBuilder me, string dataPart)
    {
        me.Path += '/' + Uri.EscapeDataString(dataPart);

        return me;
    }

    /// <summary>
    /// Fügt einen Pfad-Teil an die URL an.
    /// </summary>
    /// <param name="me">Die Instanz, die geändert werden soll.</param>
    /// <param name="part">Der URL-Teil, der an die URL angehängt werden soll.</param>
    /// <returns>Eine Referenz auf die aktuelle Instanz, um Method-Chaining zu ermöglichen.</returns>
    public static UriBuilder AddPathPart(this UriBuilder me, string part)
    {
        me.Path += '/' + Uri.EscapeDataString(part);

        return me;
    }

    /// <summary>
    /// Fügt einen Query-Parameter hinzu.
    /// </summary>
    /// <param name="me">Die Instanz, die geändert werden soll.</param>
    /// <param name="name">Der Name des Parameters.</param>
    /// <param name="value">Der Wert des Parameters.</param>
    /// <returns>Eine Referenz auf die aktuelle Instanz, um Method-Chaining zu ermöglichen.</returns>
    public static UriBuilder AddQueryParameter(this UriBuilder me, string name, string value)
    {
        if (!string.IsNullOrEmpty(me.Query))
        {
            me.Query += '&';
        }

        me.Query += Uri.EscapeDataString(name) + '=' + Uri.EscapeDataString(value);

        return me;
    }

    /// <summary>
    /// Setzt das Fragment.
    /// </summary>
    /// <param name="me">Die Instanz, die geändert werden soll.</param>
    /// <param name="fragment">Das zu setzende Fragment.</param>
    /// <returns>Eine Referenz auf die aktuelle Instanz, um Method-Chaining zu ermöglichen.</returns>
    public static UriBuilder SetFragment(this UriBuilder me, string fragment)
    {
        me.Fragment = fragment;

        return me;
    }

    /// <summary>
    /// Setzt den Port.
    /// </summary>
    /// <param name="me">Die Instanz, die geändert werden soll.</param>
    /// <param name="port">Der zu nutzende Port.</param>
    /// <returns>Eine Referenz auf die aktuelle Instanz, um Method-Chaining zu ermöglichen.</returns>
    public static UriBuilder SetPort(this UriBuilder me, int port)
    {
        me.Port = port;

        return me;
    }

    /// <summary>
    /// Setzt den Host.
    /// </summary>
    /// <param name="me">Die Instanz, die geändert werden soll.</param>
    /// <param name="host">Der zu nutzende Host.</param>
    /// <returns>Eine Referenz auf die aktuelle Instanz, um Method-Chaining zu ermöglichen.</returns>
    public static UriBuilder SetPort(this UriBuilder me, string host)
    {
        me.Host = host;

        return me;
    }

    /// <summary>
    /// Setzt das Zugriffsschema.
    /// </summary>
    /// <param name="me">Die Instanz, die geändert werden soll.</param>
    /// <param name="scheme">Das zu setzende Zugriffsschema.</param>
    /// <returns>Eine Referenz auf die aktuelle Instanz, um Method-Chaining zu ermöglichen.</returns>
    public static UriBuilder SetScheme(this UriBuilder me, string scheme)
    {
        me.Scheme = scheme;

        return me;
    }
}
