// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="AuthenticationLogic.cs" company="Lukas Tietze">
// Copyright (c) Lukas Tietze. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------------------------------

namespace Budgeteer.App.Logic.Api.Auth;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using Budgeteer.App.Config;
using Budgeteer.App.Data.Entities.Auth;

using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

/// <summary>
/// Stellt die Logik für den Login bereit.
/// </summary>
public class AuthenticationLogic : LogicBase
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
    /// <param name="config">Die Anwendungskonfiguration.</param>
    /// <param name="logger">Der zu nutzende Logger.</param>
    public AuthenticationLogic(SignInManager<User> signInManager, UserManager<User> userManager, AppConfig config, ILogger<AuthenticationLogic> logger)
        : base(config, logger)
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
        var user = await this.userManager.FindByEmailAsync(model.EMail);

        if (user == null)
        {
            return new() { Code = LoginResultCode.InvalidMail };
        }

        if (!await this.userManager.CheckPasswordAsync(user, model.Password))
        {
            return new() { Code = LoginResultCode.InvalidPassword };
        }

        await this.signInManager.SignInAsync(user, false);

        var userRoles = await this.userManager.GetRolesAsync(user);

        var authClaims = new List<Claim>
        {
            new(ClaimTypes.Email, user.Email!),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };

        authClaims.AddRange(userRoles.Select(u => new Claim(ClaimTypes.Role, u)));

        var token = this.GetToken(authClaims);

        return new()
        {
            Code = LoginResultCode.Success,
            JWT = token,
        };
    }

    /// <summary>
    /// Erzeugt ein JWT mit den gegebenen Claims.
    /// </summary>
    /// <param name="claims">Die Claims, die im JWT enthalten sein sollen.</param>
    /// <returns>Das erzeugte Token.</returns>
    private string GetToken(IEnumerable<Claim> claims)
    {
        var issuer = this.Config.Jwt.Issuer;
        var audience = this.Config.Jwt.Audience;
        var key = Encoding.ASCII.GetBytes(this.Config.Jwt.Secret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(5),
            Issuer = issuer,
            Audience = audience,
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature),
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}
