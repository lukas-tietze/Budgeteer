// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="AuthenticationController.cs" company="Lukas Tietze">
// Copyright (c) Lukas Tietze. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------------------------------

namespace Budgeteer.App.Controllers;

using Budgeteer.App.Logic.Api.Auth;

using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Dieser Controller stellt die Basisklasse für alle Controller der API dar.
/// </summary>
[ApiRoute("auth")]
[ApiController]
public class AuthenticationController : ApiControllerBase
{
    /// <summary>
    /// Loggt einen Nutzer ein.
    /// </summary>
    /// <param name="logic">Die zu nutzende Logik.</param>
    /// <param name="model">Das vom Klienten gesendete Modell.</param>
    /// <returns>Eine <see cref="Task{TResult}"/>-Instanz, deren Ergebnis 200OK mit
    /// dem Ergebnis des Logins ist.</returns>
    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync([FromServices] AuthenticationLogic logic, [FromBody] LoginPostModel model) =>
        this.Ok(await logic.LoginAsync(model));

    /// <summary>
    /// Registriert einen neuen Nutzer.
    /// </summary>
    /// <param name="logic">Die zu nutzende Logik.</param>
    /// <param name="model">Das vom Klienten gesendete Modell.</param>
    /// <returns>Eine <see cref="Task{TResult}"/>-Instanz, deren Ergebnis 200OK mit
    /// dem Ergebnis des Registrierung ist.</returns>
    [HttpPost("register")]
    public async Task<IActionResult> RegisterAsync([FromServices] AuthenticationLogic logic, [FromBody] RegisterPostModel model) =>
        this.Ok(await logic.RegisterAsync(model));
}
