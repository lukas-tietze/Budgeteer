// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="LoginResultCode.cs" company="Lukas Tietze">
// Copyright (c) Lukas Tietze. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------------------------------

namespace Budgeteer.App.Logic.Api.Auth;

/// <summary>
/// Stellt das Ergebnis eines Logins dar.
/// </summary>
public enum LoginResultCode
{
    /// <summary>
    /// Gibt an, dass der Login erfolgreich war.
    /// </summary>
    Success,

    /// <summary>
    /// Gibt an, dass der Login fehlschlug, weil die gegebene E-Mail-Adresse nicht existierte.
    /// </summary>
    InvalidMail,

    /// <summary>
    /// Gibt an, dass das Passwort nicht zur gegebenen E-Mail-Adresse passte.
    /// </summary>
    InvalidPassword,

    /// <summary>
    /// Gibt an, das der Login aufgrund eines anderen, nicht näher beschriebenen Fehlers fehlschlug.
    /// </summary>
    Error,
}
