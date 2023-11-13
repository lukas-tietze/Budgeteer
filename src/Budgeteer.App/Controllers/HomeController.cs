// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="HomeController.cs" company="Lukas Tietze">
// Copyright (c) Lukas Tietze. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------------------------------

namespace Budgeteer.App.Controllers;

using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Dieser Controller liefert die Startseite aus.
/// </summary>
public class HomeController : ControllerBase
{
    /// <summary>
    /// Liefert die Startseite aus.
    /// </summary>
    /// <returns>Die gerenderte Seite.</returns>
    public IActionResult Index() => this.View("App");
}
