// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="RestEntityBase.cs" company="Lukas Tietze">
// Copyright (c) Lukas Tietze. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------------------------------

namespace Budgeteer.Lib.Rest;

/// <summary>
/// Stellt die Basis für Entitäten dar, für die REST-Funtkionen bereitgestellte werden sollen.
/// </summary>
public class RestEntityBase
{
    /// <summary>
    /// Holt oder setzt die eindeutige Nummer des Eintrags.
    /// </summary>
    public int Id { get; set; }
}
