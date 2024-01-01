// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="IdentitySeeder.cs" company="Lukas Tietze">
// Copyright (c) Lukas Tietze. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------------------------------

namespace Budgeteer.App.Data.Seeding;

using Budgeteer.App.Data.Entities.Auth;

using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.CSharp.Syntax;

/// <summary>
/// Stellt Erweiterungsmethoden für <see cref="IServiceProvider"/> bereit, um
/// initiale Daten einzuspielen.
/// </summary>
public static class IdentitySeeder
{
    /// <summary>
    /// Implementierende Klassen stellen Methoden für die Fluent-Konfiguration der
    /// initialen Nutzer und Rollen dar.
    /// </summary>
    public interface IFluentBuilder
    {
        /// <summary>
        /// Stellt beim sicher, das der gegebene Nutzer initial angelegt ist.
        /// </summary>
        /// <param name="user">Die Daten des anzulegenden Nutzers.</param>
        /// <returns>Einen <see cref="IFluentRoleBuilder"/>, um die Rolle weiter zu konfigurieren.</returns>
        IFluentUserBuilder HasUser(InitialUser user);

        /// <summary>
        /// Stellt beim sicher, das der gegebene Nutzer initial angelegt ist.
        /// </summary>
        /// <param name="role">Die Daten des anzulegenden Nutzers.</param>
        /// <returns>Einen <see cref="IFluentUserBuilder"/>, um den Nutzer weiter zu konfigurieren.</returns>
        IFluentRoleBuilder HasRole(InitialRole role);
    }

    /// <summary>
    /// Implementierende Klassen stellen Methoden für die Fluent-konfiguration
    /// einer Rolle bereit.
    /// </summary>
    public interface IFluentRoleBuilder : IFluentBuilder
    {
    }

    /// <summary>
    /// Implementierende Klassen stellen Methoden für die Fluent-konfiguration
    /// eines Nutezrs bereit.
    /// </summary>
    public interface IFluentUserBuilder : IFluentBuilder
    {
        /// <summary>
        /// Ordnet dem zuletzt konfigurierten Nutzer Rollen zu.
        /// </summary>
        /// <param name="roleNames">Die Bezeichnungen der Rollen, die dem Nutzer zugeordnet werden sollen.</param>
        /// <returns>Einen <see cref="IFluentUserBuilder"/>, um den Nutzer weiter zu konfigurieren.</returns>
        IFluentUserBuilder WithRoles(params string[] roleNames);
    }

    /// <summary>
    /// Konfiguriert initiale vorhandene Nutzer und Rollen.
    /// </summary>
    /// <param name="services">Der zu nutzende DI-Container.</param>
    /// <param name="builderFn">Die Funktion zur Fluent-Konfiguration.</param>
    /// <returns>Eine <see cref="Task"/>-Instanz, die die asynchrone Bearbeitung der Methode darstellt.</returns>
    public static async Task SeedIdentityAsync(this IServiceProvider services, Action<IFluentBuilder> builderFn)
    {
        var builder = new FluentBuilder();

        builderFn(builder);

        await SeedUsersAsync(services, builder.Users);
    }

    /// <summary>
    /// Konfiguriert initiale vorhandene Nutzer.
    /// </summary>
    /// <param name="services">Der zu nutzende DI-Container.</param>
    /// <param name="users">Die initialen Nutzer.</param>
    /// <returns>Eine <see cref="Task"/>-Instanz, die die asynchrone Bearbeitung der Methode darstellt.</returns>
    private static async Task SeedUsersAsync(this IServiceProvider services, IEnumerable<InitialUser> users)
    {
        var context = services.GetRequiredService<AppDbContext>();
        var requiredMails = users.Select(u => u.EMail.ToUpper());

        var existingRequiredMails = context.Users
            .Where(u => requiredMails.Contains(u.NormalizedEmail))
            .Select(u => u.NormalizedEmail)
            .ToList();

        var missingMails = requiredMails.Except(existingRequiredMails).ToHashSet();

        if (missingMails.Count > 0)
        {
            var userManager = services.GetRequiredService<UserManager<User>>();

            foreach (var missingUser in users.Where(u => missingMails.Contains(u.EMail.ToUpper())))
            {
                var user = new User
                {
                    Email = missingUser.EMail,
                    EmailConfirmed = true,
                };

                await userManager.CreateAsync(user, missingUser.Password);
            }
        }
    }

    /// <summary>
    /// Konfiguriert initiale vorhandene Rollen.
    /// </summary>
    /// <param name="services">Der zu nutzende DI-Container.</param>
    /// <param name="roles">Die initialen Rollen.</param>
    /// <returns>Eine <see cref="Task"/>-Instanz, die die asynchrone Bearbeitung der Methode darstellt.</returns>
    private static async Task SeedRolesAsync(this IServiceProvider services, IEnumerable<InitialRole> roles)
    {
        var context = services.GetRequiredService<AppDbContext>();
        var requiredRoleNames = roles.Select(u => u.Name.ToUpper());

        var existingRequiredRoleNames = context.Roles
            .Where(u => requiredRoleNames.Contains(u.NormalizedName))
            .Select(u => u.NormalizedName)
            .ToList();

        var missingRoleNames = requiredRoleNames.Except(existingRequiredRoleNames).ToHashSet();

        if (missingRoleNames.Count > 0)
        {
            var roleManager = services.GetRequiredService<RoleManager<Role>>();

            foreach (var missingUser in roles.Where(u => missingRoleNames.Contains(u.EMail.ToUpper())))
            {
                var user = new User
                {
                    Email = missingUser.EMail,
                    EmailConfirmed = true,
                };

                await userManager.CreateAsync(user, missingUser.Password);
            }
        }
    }

    /// <summary>
    /// Stellt die Daten einer initial anzulegenden Rolle dar.
    /// </summary>
    public class InitialRole
    {
        /// <summary>
        /// Holt oder setzt den Anzeigenamen der Rolle.
        /// </summary>
        public required string DisplayName { get; set; }

        /// <summary>
        /// Holt oder setzt die Bezeichnung der Rolle, die deren Primärschlüssel darstellt.
        /// </summary>
        public required string Name { get; set; }
    }

    /// <summary>
    /// Stellt die Daten eines initial anzulegenden Nutzers dar.
    /// </summary>
    public class InitialUser
    {
        /// <summary>
        /// Holt oder setzt die E-Mail-Adresse des Nutzers.
        /// </summary>
        public required string EMail { get; set; }

        /// <summary>
        /// Holt oder setzt den Nutzernamen.
        /// </summary>
        public string UserName { get; set; } = string.Empty;

        /// <summary>
        /// Holt oder setzt das Passwort des Nutzers.
        /// </summary>
        public string Password { get; set; } = "Abc123!";
    }

    /// <summary>
    /// Stantdardimplementierung aller Fluent-Builder.
    /// </summary>
    private class FluentBuilder : IFluentRoleBuilder, IFluentUserBuilder, IFluentBuilder
    {
        /// <summary>
        /// Enthält die zuletzt konfigurierte Rolle.
        /// </summary>
        private InitialRole? activeRole;

        /// <summary>
        /// Enthält den zuletzt konfigurierten Nutzer.
        /// </summary>
        private InitialUser? activeUser;

        /// <summary>
        /// Holt die Auflistung der initialen Rollen.
        /// </summary>
        public List<InitialRole> Roles { get; } = new();

        /// <summary>
        /// Holt eine Sammlung von Schlüssel-Wert-Paaren, die eine Abbildung von
        /// E-Mail-Adressen initialer Nutzer auf die ihnen zugeordneten Rollen darstellt.
        /// </summary>
        public List<(string UserMail, string Role)> UserMailRoleMapping { get; } = new();

        /// <summary>
        /// Holt die Auflistung der initialen Nutzer.
        /// </summary>
        public List<InitialUser> Users { get; } = new();

        /// <inheritdoc/>
        public IFluentRoleBuilder HasRole(InitialRole role)
        {
            this.Roles.Add(role);

            this.activeUser = null;
            this.activeRole = role;

            return this;
        }

        /// <inheritdoc/>
        public IFluentUserBuilder WithRoles(params string[] roleNames)
        {
            if (this.activeUser != null)
            {
                this.UserMailRoleMapping.AddRange(roleNames.Select(r => (this.activeUser.EMail, r)));
            }

            return this;
        }

        /// <inheritdoc/>
        public IFluentUserBuilder HasUser(InitialUser user)
        {
            this.Users.Add(user);

            this.activeUser = user;
            this.activeRole = null;

            return this;
        }
    }
}
