// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="LoginResultModel.cs" company="Lukas Tietze">
// Copyright (c) Lukas Tietze. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------------------------------

namespace Budgeteer.App.Logic.Api.Auth;

/// <summary>
/// Modelliert das Ergebnis eines Login-Prozesses.
/// </summary>
public class LoginResultModel
{
    /// <summary>
    /// Holt oder setzt den Ergebniscode des Logins.
    /// </summary>
    public LoginResultCode Code { get; set; }

    /// <summary>
    /// Holt oder setzt das JWT, für den eingeloggten Nutzer.
    /// </summary>
    public string JWT { get; set; } = string.Empty;
}
