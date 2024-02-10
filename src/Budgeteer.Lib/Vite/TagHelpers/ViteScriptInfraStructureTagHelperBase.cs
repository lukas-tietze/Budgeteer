// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="ViteScriptInfraStructureTagHelperBase.cs" company="Lukas Tietze">
// Copyright (c) Lukas Tietze. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------------------------------

namespace Budgeteer.Lib.Vite.TagHelpers;

using Budgeteer.Lib.Taghelpers;

using Microsoft.AspNetCore.Http;

/// <summary>
/// Stellt die Basisklasse für Taghelper dar, über die Skripte
/// angefordert, geladen oder vorgeladen (preload) werden können.
/// </summary>
public abstract class ViteScriptInfraStructureTagHelperBase : RenderedSyncTagHelperBase
{
    /// <summary>
    /// Der Schlüssel für <see cref="HttpContext.Items"/>.
    /// </summary>
    private const string ItemsKey = "Ipml.Extensions.AspNetCore.Vite.TagHelpers.RequiredScripts";

    /// <summary>
    /// Das Objekt zum Zugriff auf den aktuellen <see cref="HttpContext"/>.
    /// </summary>
    private readonly IHttpContextAccessor httpContextAccessor;

    /// <summary>
    /// Die Sammlung der benötigten Skripte.
    /// </summary>
    private ViteRequiredScripts? requiredScripts;

    /// <summary>
    /// Initialisiert eine neue Instanz der <see cref="ViteScriptInfraStructureTagHelperBase"/> Klasse.
    /// </summary>
    /// <param name="httpContextAccessor">Das Objekt zum Zugriff auf den aktuellen <see cref="HttpContext"/>.</param>
    public ViteScriptInfraStructureTagHelperBase(IHttpContextAccessor httpContextAccessor)
    {
        this.httpContextAccessor = httpContextAccessor;
    }

    /// <summary>
    /// Holt die Sammlung der benötigten Skripte.
    /// </summary>
    internal ViteRequiredScripts RequiredScripts
    {
        get
        {
            if (this.requiredScripts is null)
            {
                var httpContext = this.httpContextAccessor.HttpContext ?? throw new NotSupportedException("Missing HTTP-Context!");

                if (httpContext.Items.TryGetValue(ItemsKey, out var maybeRequiredScripts) &&
                    maybeRequiredScripts is ViteRequiredScripts requiredScripts)
                {
                    this.requiredScripts = requiredScripts;
                }
                else
                {
                    this.requiredScripts = [];

                    httpContext.Items.Add(ItemsKey, this.requiredScripts);
                }
            }

            return this.requiredScripts;
        }
    }
}
