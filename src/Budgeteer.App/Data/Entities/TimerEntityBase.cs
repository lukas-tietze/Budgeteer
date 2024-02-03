// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="TimerEntityBase.cs" company="Lukas Tietze">
// Copyright (c) Lukas Tietze. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------------------------------

namespace Budgeteer.App.Data.Entities;

/// <summary>
/// Stellt die Basis aller Entitäten dar, die Zeitstempel enthalten.
/// </summary>
public class TimerEntityBase : EntityBase, IHasTimes
{
    /// <inheritdoc/>
    public DateTime Created { get; set; }

    /// <inheritdoc/>
    public DateTime Modified { get; set; }
}
