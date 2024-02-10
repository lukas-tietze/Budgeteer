// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="EntityConfigurationBase.cs" company="Lukas Tietze">
// Copyright (c) Lukas Tietze. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------------------------------

namespace Budgeteer.App.Data.Entities;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

/// <summary>
/// Stellt die Basis für die Konfiguration von Entitäten dar, die von <see cref="EntityBase"/>
/// ableiten.
/// </summary>
/// <typeparam name="TEntity">Der Typ der zu konfigurierenden Entität.</typeparam>
public class EntityConfigurationBase<TEntity> : ConfigurationBase<TEntity>
    where TEntity : EntityBase
{
    /// <inheritdoc/>
    public override void Configure(EntityTypeBuilder<TEntity> builder)
    {
        base.Configure(builder);

        builder.HasKey(x => x.Id);
    }
}
