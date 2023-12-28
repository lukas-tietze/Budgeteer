// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="RegisterPostModel.cs" company="Lukas Tietze">
// Copyright (c) Lukas Tietze. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------------------------------

namespace Budgeteer.App.Logic.Api.Auth;

/// <summary>
/// Modelliert die Daten, die zum Registrieren eines Nutzers
/// vom Klienten gesendet werden.
/// </summary>
public class RegisterPostModel
{
    /// <summary>
    /// Holt oder setzt die EMail-Adresse des neuen Nutzers.
    /// </summary>
    public string EMail { get; set; } = string.Empty;

    /// <summary>
    /// Holt oder setzt das initiale Passwort des Nutzers.
    /// </summary>
    public string Password { get; set; } = string.Empty;
}
