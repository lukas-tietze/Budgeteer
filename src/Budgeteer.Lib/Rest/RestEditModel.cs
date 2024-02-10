// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="RestEditModel.cs" company="Lukas Tietze">
// Copyright (c) Lukas Tietze. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------------------------------

namespace Budgeteer.Lib.Rest;

/// <summary>
/// Stellt die Basisklasse für Modelle dar, die zum Aktualisieren
/// eines Datensatzes via Rest-API genutzt werden können.
/// </summary>
public class RestEditModel
{
    /// <summary>
    /// Holt oder setzt die ID des modifizierten Datensatzes.
    /// </summary>
    public int Id { get; set; }
}
