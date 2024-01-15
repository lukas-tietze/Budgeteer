// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="JwtConfig.cs" company="Lukas Tietze">
// Copyright (c) Lukas Tietze. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------------------------------

namespace Budgeteer.App.Config;

/// <summary>
/// Stellt die Konfiguration für die Ausstellung von JWTs dar.
/// </summary>
public class JwtConfig
{
    /// <summary>
    /// Holt oder setzt die gültigen Audienz des Tokens.
    /// </summary>
    public string Audience { get; set; } = string.Empty;

    /// <summary>
    /// Holt oder setzt den gültigen Aussteller von JWTs.
    /// </summary>
    public string Issuer { get; set; } = string.Empty;

    /// <summary>
    /// Holt oder setzt einen Geheimwert für die Signierung von JWTs.
    /// </summary>
    public string Secret { get; set; } = string.Empty;
}
