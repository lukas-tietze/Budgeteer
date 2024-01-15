// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="LogicBase.cs" company="Lukas Tietze">
// Copyright (c) Lukas Tietze. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------------------------------

namespace Budgeteer.App.Logic;

using Budgeteer.App.Config;

/// <summary>
/// Stellt die Basisklasse für alle Logiken dar.
/// </summary>
public class LogicBase
{
    /// <summary>
    /// Initialisiert eine neue Instanz der <see cref="LogicBase"/> Klasse.
    /// </summary>
    /// <param name="config">Die Anwendungskonfiguration.</param>
    /// <param name="logger">Der zu nutzende Logger.</param>
    protected LogicBase(AppConfig config, ILogger<LogicBase> logger)
    {
        this.Config = config;
        this.Logger = logger;
    }

    /// <summary>
    /// Holt einen Logger.
    /// </summary>
    public ILogger Logger { get; }

    /// <summary>
    /// Holt die Anwendungskonfiguration.
    /// </summary>
    public AppConfig Config { get; }
}
