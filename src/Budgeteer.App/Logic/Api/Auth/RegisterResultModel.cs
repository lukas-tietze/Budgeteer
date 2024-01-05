// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="RegisterResultModel.cs" company="Lukas Tietze">
// Copyright (c) Lukas Tietze. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------------------------------

namespace Budgeteer.App.Logic.Api.Auth;

/// <summary>
/// Modelliert das Ergebnis einer Registrierung.
/// </summary>
public class RegisterResultModel
{
    /// <summary>
    /// Holt oder setzt den Ergebnis-Code.
    /// </summary>
    public RegisterResultCode Code { get; set; }
}
