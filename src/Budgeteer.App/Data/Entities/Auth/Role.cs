// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="Role.cs" company="Lukas Tietze">
// Copyright (c) Lukas Tietze. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------------------------------

namespace Budgeteer.App.Data.Entities.Auth;

using Microsoft.AspNetCore.Identity;

/// <summary>
/// Stellt eine Rolle dar.
/// </summary>
public class Role : IdentityRole<Guid>
{
}
