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
    /// <returns>Eine <see cref="Task"/>-Instanz, die die asynchrone Bearbeitung der Methode darstellt.</returns>
    public static async Task SeedAsync(IServiceProvider services)
    {
        using var scope = services.CreateScope();

        await scope.ServiceProvider.SeedIdentityAsync(cfg => cfg
            .HasRole(new() { Name = "admin", DisplayName = "Admin" })
            .WithRoleClaims(Claims.ViewAdminSection)
            .HasRole(new() { Name = "user", DisplayName = "Benutzer (Standard)" })
            .HasUser(new() { Email = "lukas.tietzermp@gmail.com" })
            .WithRoles("admin"));
    }
}
