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
    /// Liefert einen Redirect zur Vue-App aus.
    /// </summary>
    /// <returns>Der Redirect-Befhehl.</returns>
    [HttpGet]
    public IActionResult Index() => this.Redirect("/app");
}
