// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="Extensions.cs" company="Lukas Tietze">
// Copyright (c) Lukas Tietze. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------------------------------

namespace Budgeteer.App;

using Microsoft.AspNetCore.Identity;

/// <summary>
/// Enthält verschiedene Erweiterungsmethoden.
/// </summary>
public static class Extensions
{
    /// <summary>
    /// Wirft eine Exception, wenn 
    /// </summary>
    /// <param name="identityResult"></param>
    public static void ThrowOnError(this IdentityResult identityResult)
    {
        if (!identityResult.Succeeded)
        {
            var message = "Identity-Action finished with errors:" + Environment.NewLine + string.Join(Environment.NewLine, identityResult.Errors.Select(e => $"  {e.Code}: {e.Description}"));

            var exception = new Exception(message);

            exception.Data.Add("IdentityErrors", identityResult.Errors);

            throw exception;
        }
    }
}
