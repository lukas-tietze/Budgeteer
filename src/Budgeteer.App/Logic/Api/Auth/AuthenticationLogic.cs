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

    /// <summary>
    /// Führt eine Registrierung durch.
    /// </summary>
    /// <param name="model">Die eingegebenen Nutzerdaten.</param>
    /// <returns>Einen <see cref="Task{TResult}"/>, der die asynchrone Bearbeitung der Methode darstellt
    /// und dessen Ergebnis den Erfolg oder mögliche Fehler bei der Registrierung darstellt.</returns>
    public Task<RegisterResultModel> RegisterAsync(RegisterPostModel model) => throw new NotImplementedException();

    /// <summary>
    /// Führt einen Login mit den gegebenen Daten durch.
    /// </summary>
    /// <param name="model">Die eingegebenen Login-Daten.</param>
    /// <returns>Einen <see cref="Task{TResult}"/>, der die asynchrone Bearbeitung der Methode darstellt
    /// und dessen Ergebnis den Erfolg oder mögliche Fehler beim Login darstellt.</returns>
    public async Task<LoginResultModel> LoginAsync(LoginPostModel model)
    {
        var result = await this.signInManager.PasswordSignInAsync(model.EMail, model.Password, model.RememberMe, lockoutOnFailure: false);

        return new LoginResultModel
        {
            Code = result.Succeeded ? LoginResultCode.Sucess : LoginResultCode.InvalidData,
        };
    }
}
