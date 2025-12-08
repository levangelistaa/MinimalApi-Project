using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinimalApi.DTOs;
using MinimalApi.Infrastructure.Database;
using MinimalAPI.Domain.Interfaces;
using MinimalAPI.Domain.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IAdminService, AdminService>();

builder.Services.AddDbContext<ContextDb>(options => {
    options.UseMySql(
        builder.Configuration.GetConnectionString("mysql"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("mysql"))
    );
});

var app = builder.Build();

app.MapGet("/", () => "Seja bem-vindo!");

app.MapPost("/login", ([FromBody] LoginDTO loginDTO, IAdminService adminService) =>
{
    if (adminService.Login(loginDTO) != null)
    {
        return Results.Ok("Login com sucesso");
    }
    else
    {
        return Results.Unauthorized();
    }
});

app.Run();
