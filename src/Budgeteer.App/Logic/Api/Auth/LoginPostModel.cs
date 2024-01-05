// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="LoginPostModel.cs" company="Lukas Tietze">
// Copyright (c) Lukas Tietze. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------------------------------

namespace Budgeteer.App.Logic.Api.Auth;

/// <summary>
/// Modelliert die Daten, die zum Einloggen eines Nutzers
/// vom Klienten gesendet werden.
/// </summary>
public class LoginPostModel
{
    /// <summary>
    /// Holt oder setzt die E-Mail-Adresse des Nutzers.
    /// </summary>
    public string EMail { get; set; } = string.Empty;

    /// <summary>
    /// Holt oder setzt das Passwort des Nutzers.
    /// </summary>
    public string Password { get; set; } = string.Empty;

    /// <summary>
    /// Holt oder setzt einen Wert, der angibt, ob der Login gespeichert werden soll oder nicht.
    /// </summary>
    public bool RememberMe { get; set; } = false;
}
