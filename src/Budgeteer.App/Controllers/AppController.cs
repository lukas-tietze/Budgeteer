// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="AppController.cs" company="Lukas Tietze">
// Copyright (c) Lukas Tietze. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------------------------------

namespace Budgeteer.App.Controllers;

using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Dieser Controller liefert die Vue-App aus.
/// </summary>
[Route("[controller]")]
public class AppController : ControllerBase
{
    /// <summary>
    /// Liefert die Vue-Appaus.
    /// </summary>
    /// <returns>Die gerenderte Seite.</returns>
    [HttpGet]
    [HttpGet("*")]
    public IActionResult Index() => this.View();
}
