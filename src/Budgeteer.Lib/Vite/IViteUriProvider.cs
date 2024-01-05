// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="IViteUriProvider.cs" company="Lukas Tietze">
// Copyright (c) Lukas Tietze. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------------------------------

namespace Budgeteer.Lib.Vite;

/// <summary>
/// Implementierende Klassen stellen Methoden bereit, um URIs für Ressourcen zu
/// erzeugen, die über Vite abgerufen werden sollen, entweder vom Vite-Dev-Server
/// oder von statischen Dateien, die Vite build erzeugt hat.
/// </summary>
public interface IViteUriProvider
{
    /// <summary>
    /// Erzeugt die URI für eine angefragte Ressource.
    /// </summary>
    /// <param name="ressourcePath">Der Pfad der angefragten Ressource.</param>
    /// <returns>Die erzeugte URI.</returns>
    public string MakeUri(string ressourcePath);
}
