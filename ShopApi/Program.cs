using Application.Contracts;
using Application.Services;
using Infrastructure;
using Infrastructure.repositories;
using Microsoft.EntityFrameworkCore;
using Domain.Models.Users;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IShopRepository, ShopRepository>();
builder.Services.AddScoped<IShopService, ShopService>();

builder.Services.AddDbContext<DataBaseContext>(options =>
    options.UseSqlServer("Server=.;Database=ShopProject;Integrated Security=true;TrustServerCertificate=true"));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();