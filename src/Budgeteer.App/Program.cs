// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Lukas Tietze">
// Copyright (c) Lukas Tietze. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------------------------------

using Budgeteer.App.Config;
using Budgeteer.Lib.Vite;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddHttpContextAccessor()
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

var config = new AppConfig();
app.Configuration.Bind(config);

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Use(async (context, next) =>
{
    context.Items["Config"] = config;

    await next();
});

app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}");

app.Run();
