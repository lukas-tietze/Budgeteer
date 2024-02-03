// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="AppDbContext.cs" company="Lukas Tietze">
// Copyright (c) Lukas Tietze. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------------------------------

namespace Budgeteer.App.Data;

using Budgeteer.App.Data.Entities;
using Budgeteer.App.Data.Entities.Auth;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// Ermöglicht den Zugriff auf die Datenbank.
/// </summary>
public class AppDbContext : IdentityDbContext<User, Role, Guid>
{
    /// <summary>
    /// Initialisiert eine neue Instanz der <see cref="AppDbContext"/> Klasse.
    /// </summary>
    public AppDbContext() => this.SetupTimerListener();

    /// <summary>
    /// Initialisiert eine neue Instanz der <see cref="AppDbContext"/> Klasse.
    /// </summary>
    /// <param name="options">Die Konfiguration der Datenbank.</param>
    public AppDbContext(DbContextOptions options)
        : base(options) => this.SetupTimerListener();

    /// <summary>
    /// Holt das Datenbankset der Budgets.
    /// </summary>
    public DbSet<Budget> Budgets => this.Set<Budget>();

    /// <summary>
    /// Holt das Datenbankset der Schlagwörter.
    /// </summary>
    public DbSet<Tag> Tags => this.Set<Tag>();

    /// <summary>
    /// Holt das Datenbankset der Zuordnung von Schlagwörtern zu Budgets.
    /// </summary>
    public DbSet<TagToBudget> TagToBudgets => this.Set<TagToBudget>();

    /// <inheritdoc/>
    public override void Dispose()
    {
        GC.SuppressFinalize(this);

        this.ChangeTracker.Tracked -= this.OnEntityTracked;
        this.ChangeTracker.StateChanged -= this.OnEntityStateChanged;

        base.Dispose();
    }

    /// <summary>
    /// Falls <paramref name="entity"/> <see cref="IHasTimes"/> implementiert und
    /// <paramref name="state"/> anzeigt, dass die Entität hinzugefügt oder
    /// geändert wurde, werden die entsprechenden Zeitstempel aktualisiert.
    /// </summary>
    /// <param name="entity">Die Entität, deren Zustand sich änderte.</param>
    /// <param name="state">Der neue Zustand der Entität.</param>
    private static void TryUpdateEntityTimes(object entity, EntityState state)
    {
        if (entity is IHasTimes entityWithTimes)
        {
            if (state is EntityState.Added)
            {
                entityWithTimes.Created = DateTime.UtcNow;
                entityWithTimes.Modified = DateTime.UtcNow;
            }
            else if (state is EntityState.Modified)
            {
                entityWithTimes.Modified = DateTime.UtcNow;
            }
        }
    }

    /// <summary>
    /// Behandelt die Änderung des Status einer Entität.
    /// </summary>
    /// <param name="sender">Der Absender des Ereignisses.</param>
    /// <param name="e">Die Ereignis-Parameter.</param>
    private void OnEntityStateChanged(object? sender, Microsoft.EntityFrameworkCore.ChangeTracking.EntityStateChangedEventArgs e) =>
        TryUpdateEntityTimes(e.Entry.Entity, e.NewState);

    /// <summary>
    /// Behandelt das Hinzufügen einer Entität zum Change-Tracker.
    /// </summary>
    /// <param name="sender">Der Absender des Ereignisses.</param>
    /// <param name="e">Die Ereignis-Parameter.</param>
    private void OnEntityTracked(object? sender, Microsoft.EntityFrameworkCore.ChangeTracking.EntityTrackedEventArgs e) =>
        TryUpdateEntityTimes(e.Entry.Entity, e.Entry.State);

    /// <summary>
    /// Registriert Event-Listener für das Hinzufügen einer Entität und
    /// das Ändern des Status einer Entität.
    /// </summary>
    private void SetupTimerListener()
    {
        this.ChangeTracker.Tracked += this.OnEntityTracked;
        this.ChangeTracker.StateChanged += this.OnEntityStateChanged;
    }
}
