// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="AppDbContext.cs" company="Lukas Tietze">
// Copyright (c) Lukas Tietze. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------------------------------

namespace Budgeteer.App.Data;

using Budgeteer.App.Data.Entities.Auth;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// Ermöglicht den Zugriff auf die Datenbank.
/// </summary>
public class AppDbContext : IdentityDbContext<User>
{
    /// <summary>
    /// Initialisiert eine neue Instanz der <see cref="AppDbContext"/> Klasse.
    /// </summary>
    public AppDbContext()
    {
    }

    /// <summary>
    /// Initialisiert eine neue Instanz der <see cref="AppDbContext"/> Klasse.
    /// </summary>
    /// <param name="options">Die Konfiguration der Datenbank.</param>
    public AppDbContext(DbContextOptions options)
        : base(options)
    {
    }
}
