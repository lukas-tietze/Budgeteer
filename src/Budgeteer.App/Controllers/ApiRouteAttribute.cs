// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="ApiRouteAttribute.cs" company="Lukas Tietze">
// Copyright (c) Lukas Tietze. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------------------------------

namespace Budgeteer.App.Controllers;

using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Stellt eine Route der API dar.
/// </summary>
public class ApiRouteAttribute : RouteAttribute
{
    /// <summary>
    /// Initialisiert eine neue Instanz der <see cref="ApiRouteAttribute"/> Klasse.
    /// </summary>
    /// <param name="path">Der Pfad innerhalb der API.</param>
    public ApiRouteAttribute(string path)
        : base("api/" + path.TrimStart('/'))
    {
    }
}
