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
/// <remarks>
/// Initialisiert eine neue Instanz der <see cref="ApiRouteAttribute"/> Klasse.
/// </remarks>
/// <param name="path">Der Pfad innerhalb der API.</param>
public class ApiRouteAttribute(string path) : RouteAttribute("api/" + path.TrimStart('/'))
{
}
