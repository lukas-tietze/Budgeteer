// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Lukas Tietze">
// Copyright (c) Lukas Tietze. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------------------------------
namespace Budgeteer.App;

using Budgeteer.Lib.Vite;

/// <summary>
/// Einstiegspunkt.
/// </summary>
public static class Program
{
    /// <summary>
    /// Einstiegspunkt.
    /// </summary>
    /// <param name="args">Externe Aufrufparameter.</param>
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services
            .AddVite(new() { DevServerUri = "http://localhost:4173", })
            .AddRazorPages();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            //// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllers();

        app.UseEndpoints(endpoints => endpoints.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}"));

        app.Run();
    }
}
