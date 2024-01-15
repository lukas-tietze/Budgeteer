// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Lukas Tietze">
// Copyright (c) Lukas Tietze. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------------------------------

using System.Text;

using Budgeteer.App.Config;
using Budgeteer.App.Data;
using Budgeteer.App.Data.Entities.Auth;
using Budgeteer.App.Data.Seeding;
using Budgeteer.App.Logic;
using Budgeteer.Lib.Vite;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);
var config = new AppConfig(builder.Configuration);

// Add services to the container.
builder.Services
    .AddApp()
    .AddHttpContextAccessor()
    .AddVite(new() { DevServerUri = "http://localhost:4173", })
    .AddSingleton(config);

builder.Services.AddDbContext<AppDbContext>(cfg => cfg
    .UseSqlServer(builder.Configuration.GetConnectionString("Default"))
    .EnableSensitiveDataLogging(builder.Environment.IsDevelopment())
    .EnableThreadSafetyChecks(builder.Environment.IsDevelopment()));

//// TODO
////builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services
    .AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.SaveToken = true;
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidAudience = config.Jwt.Audience,
            ValidIssuer = config.Jwt.Issuer,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.Jwt.Secret)),
        };
    });

builder.Services
    .AddIdentity<User, Role>(options =>
    {
        options.SignIn.RequireConfirmedAccount = true;
        options.SignIn.RequireConfirmedEmail = true;
        options.User.RequireUniqueEmail = true;
    })
    .AddEntityFrameworkStores<AppDbContext>();

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
