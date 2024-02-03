// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="IHasTimes.cs" company="Lukas Tietze">
// Copyright (c) Lukas Tietze. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------------------------------

namespace Budgeteer.App.Data.Entities;

/// <summary>
/// Implementierende Klassen stellen Zeitstempel für Erstellen und Bearbeiten bereit.
/// </summary>
public interface IHasTimes
{
    /// <summary>
    /// Holt oder setzt den Zeitpunkt, zu dem die Entität erstellt wurde.
    /// </summary>
    DateTime Created { get; set; }

    /// <summary>
    /// Holt oder setzt den Zeitpunkt, zu dem die Entität zuletzt verändert wurde.
    /// </summary>
    DateTime Modified { get; set; }
}
