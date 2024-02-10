// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="LogicBase.cs" company="Lukas Tietze">
// Copyright (c) Lukas Tietze. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------------------------------

namespace Budgeteer.Lib;

/// <summary>
/// Stellt die Basisklasse für alle Logiken dar.
/// </summary>
/// <param name="logger">Der zu nutzende Logger.</param>
public class LogicBase(ILogger<LogicBase> logger)
{
    /// <summary>
    /// Holt einen Logger.
    /// </summary>
    public ILogger Logger { get; } = logger;
}
