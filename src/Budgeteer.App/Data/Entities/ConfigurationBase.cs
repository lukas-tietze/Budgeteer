// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="ConfigurationBase.cs" company="Lukas Tietze">
// Copyright (c) Lukas Tietze. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------------------------------

namespace Budgeteer.App.Data.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ConfigurationBase<T> : IEntityTypeConfiguration<T>
    where T : class
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {

    }
}
