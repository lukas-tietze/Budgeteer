// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="RestEditResultModel.cs" company="Lukas Tietze">
// Copyright (c) Lukas Tietze. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------------------------------

namespace Budgeteer.Lib.Rest;

/// <summary>
/// Stellt das Ergebnis einer RESTR-Funktion dar, die einen Datensatz anlegt oder bearbeitet.
/// </summary>
public class RestEditResultModel
{
    /// <summary>
    /// 
    /// </summary>
    public bool Success { get; set; }

    public int? ErrorCode { get; set; }

    public int? EntityId { get; set; }
}
