// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="AuthenticationLogic.cs" company="Lukas Tietze">
// Copyright (c) Lukas Tietze. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------------------------------

namespace Budgeteer.App.Logic.Api.Auth;

using Budgeteer.App.Data.Entities.Auth;

using Microsoft.AspNetCore.Identity;

/// <summary>
/// Stellt die Logik für den Login bereit.
/// </summary>
public class AuthenticationLogic
{
    /// <summary>
    /// Der Dienst zum Einloggen des Nutzers.
    /// </summary>
    private readonly SignInManager<User> signInManager;

    /// <summary>
    /// Der Dienst zum Verwalten der Nutzer.
    /// </summary>
    private readonly UserManager<User> userManager;

    /// <summary>
    /// Initialisiert eine neue Instanz der <see cref="AuthenticationLogic"/> Klasse.
    /// </summary>
    /// <param name="signInManager">Der Dienst zum Einloggen des Nutzers.</param>
    /// <param name="userManager">Der Dienst zum Verwalten der Nutzer.</param>
    public AuthenticationLogic(SignInManager<User> signInManager, UserManager<User> userManager)
    {
        this.signInManager = signInManager;
        this.userManager = userManager;
    }

    public async Task<RegisterResultModel> RegisterAsync(RegisterPostModel model)
    {
        var user = new User { Email = model.EMail };
        var addResult = await this.userManager.CreateAsync(user);

        if (!addResult.Succeeded)
        {
        }

        var pwResult = await this.userManager.AddPasswordAsync(user, model.Password);

        if (!pwResult.Succeeded)
        {
        }

        return new RegisterResultModel
        {
        };
    }

    public async Task<LoginResultModel> LoginAsync(LoginPostModel model)
    {
        var result = await this.signInManager.PasswordSignInAsync(model.EMail, model.Password, model.RememberMe, lockoutOnFailure: true);

        return new LoginResultModel
        {
        };
    }
}
