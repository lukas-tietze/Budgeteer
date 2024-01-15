// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="AppConfig.cs" company="Lukas Tietze">
// Copyright (c) Lukas Tietze. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------------------------------

namespace Budgeteer.App.Config;

/// <summary>
/// Stellt die Anwendungskonfiguration dar.
/// </summary>
public class AppConfig
{
    /// <summary>
    /// Initialisiert eine neue Instanz der <see cref="AppConfig"/> Klasse.
    /// </summary>
    public AppConfig()
    {
    }

    /// <summary>
    /// Initialisiert eine neue Instanz der <see cref="AppConfig"/> Klasse.
    /// </summary>
    /// <param name="config">Die Konfiguration, aus der die Daten gelesen werden sollen.</param>
    public AppConfig(IConfiguration config) => config.Bind(this);

    /// <summary>
    /// Holt oder setzt die Konfiguration der Anwendungspfade.
    /// </summary>
    public PathConfig Paths { get; set; } = new();

    /// <summary>
    /// Holt oder setzt die Konfiguration für die Ausstellung von JWTs.
    /// </summary>
    public JwtConfig Jwt { get; set; } = new();
}
