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
    Sucess,

    /// <summary>
    /// Gibt an, das ungültige Logindaten übergeben wurden.
    /// </summary>
    InvalidData,
}
