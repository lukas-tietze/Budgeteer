// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="Seeder.cs" company="Lukas Tietze">
// Copyright (c) Lukas Tietze. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------------------------------

namespace Budgeteer.App.Data.Seeding;

/// <summary>
/// Enthält die Logik zum Seeden der Anwendung.
/// </summary>
public static class Seeder
{
    /// <summary>
    /// Initialisiert die Datenbank mit vorgegebenen Daten.
    /// </summary>
    /// <param name="services">Die Sammlung der Dienste.</param>
    public static async Task SeedAsync(IServiceProvider services)
    {
        services.SeedIdentityAsync(cfg => cfg.HasRole(new()
        {
            Name = "admin",
            DisplayName = "Admin",
        })
        .HasRole(new()
        {
            Name = "user",
            DisplayName = "Benutzer (Standard)",
        })
        .HasUser(new()
        {
            EMail = "lukas.tietzermp@gmail.com",
            UserName = "Lukas Tietze",
        })
        .WithRoles("admin"));
    }
}
