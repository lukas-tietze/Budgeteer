// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="IServiceCollectionExtensions.cs" company="Lukas Tietze">
// Copyright (c) Lukas Tietze. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------------------------------

namespace Budgeteer.App.Logic;

using Budgeteer.App.Logic.Api;

/// <summary>
/// Stellt Erweiterungsmethoden für <see cref="IServiceCollection"/> bereit.
/// </summary>
public static class IServiceCollectionExtensions
{
    /// <summary>
    /// Registriert die Dienste der App in <paramref name="services"/>.
    /// </summary>
    /// <param name="services">Die Sammlung, in der die Dienste registriert werden sollen.</param>
    /// <returns><paramref name="services"/>, um Method-Chaining zu ermöglichen.</returns>
    public static IServiceCollection AddApp(this IServiceCollection services) => services
        .AddApi();
}
