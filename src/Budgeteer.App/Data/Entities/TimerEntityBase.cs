// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="TimerEntityBase.cs" company="Lukas Tietze">
// Copyright (c) Lukas Tietze. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------------------------------

namespace Budgeteer.App.Data.Entities;

/// <summary>
/// Stellt die Basis aller Entitäten dar, die Zeitstempel enthalten.
/// </summary>
public class TimerEntityBase : EntityBase
{
    /// <summary>
    /// Holt oder setzt den Zeitpunkt, zu dem die Entität erstellt wurde.
    /// </summary>
    public DateTime Created { get; set; }

    /// <summary>
    /// Holt oder setzt den Zeitpunkt, zu dem die Entität zuletzt verändert wurde.
    /// </summary>
    public DateTime Modified { get; set; }
}
