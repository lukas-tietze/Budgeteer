// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="User.cs" company="Lukas Tietze">
// Copyright (c) Lukas Tietze. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------------------------------

namespace Budgeteer.App.Data.Entities.Auth;

using Microsoft.AspNetCore.Identity;

/// <summary>
/// Stellt einen Nutzer dar.
/// </summary>
public class User : IdentityUser<Guid>
{
}
