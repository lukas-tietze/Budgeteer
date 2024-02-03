// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="EntityBase.cs" company="Lukas Tietze">
// Copyright (c) Lukas Tietze. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------------------------------

namespace Budgeteer.App.Data.Entities;

using Budgeteer.Lib.Rest;

using Microsoft.EntityFrameworkCore;

/// <summary>
/// Stellt die Basis aller Entitäten dar.
/// </summary>
[PrimaryKey(nameof(Id))]
public class EntityBase : RestEntityBase
{
}
