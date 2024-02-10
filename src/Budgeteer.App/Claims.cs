﻿// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="Claims.cs" company="Lukas Tietze">
// Copyright (c) Lukas Tietze. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------------------------------

namespace Budgeteer.App;

/// <summary>
/// Enthält String-Konstanten, die alle verfügbaren Claims der Anwendung darstellen.
/// </summary>
public static class Claims
{
    /// <summary>
    /// Holt die Bezeichnung des Claims für den Zugriff auf den Admin-Bereich.
    /// </summary>
    public static string ViewAdminSection { get; } = nameof(ViewAdminSection);
}
