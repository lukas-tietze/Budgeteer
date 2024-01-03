// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Lukas Tietze">
// Copyright (c) Lukas Tietze. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------------------------------

using Budgeteer.App.Config;
using Budgeteer.App.Data;
using Budgeteer.App.Data.Entities.Auth;
using Budgeteer.App.Data.Seeding;
using Budgeteer.Lib.Vite;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var config = new AppConfig(builder.Configuration);

// Add services to the container.
builder.Services
    .AddHttpContextAccessor()
    .AddVite(new() { DevServerUri = "http://localhost:4173", })
    .AddSingleton(config);

builder.Services.AddAuthentication(options =>
{
    //// TODO
});

builder.Services.AddIdentity<User, Role>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
    options.SignIn.RequireConfirmedEmail = true;
    options.User.RequireUniqueEmail = true;
})
.AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddDbContext<AppDbContext>(cfg => cfg
    .UseSqlServer(builder.Configuration.GetConnectionString("Default"))
    .EnableSensitiveDataLogging(builder.Environment.IsDevelopment())
    .EnableThreadSafetyChecks(builder.Environment.IsDevelopment()));

builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Use(async (context, next) =>
{
    context.Items["Config"] = config;

    await next();
});

app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}");

await Seeder.SeedAsync(app.Services);

app.Run();
