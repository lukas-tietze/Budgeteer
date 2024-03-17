﻿// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="IServiceCollectionExtensions.cs" company="Lukas Tietze">
// Copyright (c) Lukas Tietze. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------------------------------

namespace Budgeteer.App.Logic.Api;

using Budgeteer.App.Logic.Api.Auth;
using Budgeteer.App.Logic.Api.Setup;

/// <summary>
/// Stellt Erweiterungsmethoden für <see cref="IServiceCollection"/> bereit.
/// </summary>
public static class IServiceCollectionExtensions
{
    /// <summary>
    /// Registriert die Api-Dienste in <paramref name="services"/>.
    /// </summary>
    /// <param name="services">Die Sammlung, in der die Dienste registriert werden sollen.</param>
    /// <returns><paramref name="services"/>, um Method-Chaining zu ermöglichen.</returns>
    public static IServiceCollection AddApi(this IServiceCollection services) => services
        .AddAuthServices()
        .AddSetup();
}
