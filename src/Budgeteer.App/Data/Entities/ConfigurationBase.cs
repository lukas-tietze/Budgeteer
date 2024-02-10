// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="ConfigurationBase.cs" company="Lukas Tietze">
// Copyright (c) Lukas Tietze. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------------------------------

namespace Budgeteer.App.Data.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

/// <summary>
/// Stellt die Basis für die Konfiguration von Entitäten bereit.
/// </summary>
/// <typeparam name="T">Der Typder zu konfigurierenden Entität.</typeparam>
public class ConfigurationBase<T> : IEntityTypeConfiguration<T>
    where T : class
{
    /// <summary>
    /// Holt die Bezeichnung der Tabelle.
    /// </summary>
    public virtual string TableName => typeof(T).Name;

    /// <summary>
    /// Holt die Bezeichnung des Schemas der Tabelle.
    /// </summary>
    public virtual string Schema => typeof(T).Name;

    /// <inheritdoc/>
    public virtual void Configure(EntityTypeBuilder<T> builder) => builder.ToTable(name: this.TableName, schema: this.Schema);
}
