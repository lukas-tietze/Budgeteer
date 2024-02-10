// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="LogicBase{TContext}.cs" company="Lukas Tietze">
// Copyright (c) Lukas Tietze. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------------------------------

namespace Budgeteer.Lib;

/// <summary>
/// Stellt die Basisklasse für alle Logiken dar.
/// </summary>
/// <typeparam name="TContext">Der Typ des Datenbankkontextes.</typeparam>
public class LogicBase<TContext>(TContext context, ILogger<LogicBase<TContext>> logger) : LogicBase(logger)
{
    /// <summary>
    /// Holt den genutzten Datenbankkontext.
    /// </summary>
    protected TContext Context { get; } = context;
}
