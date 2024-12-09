using System.Text;
using Application.Contracts;
using Application.Services;
using Infrastructure;
using Infrastructure.repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddSingleton<JwtHelper>(provider =>
{
    var configuration = provider.GetRequiredService<IConfiguration>();
    var jwtOptions = configuration.GetSection("JwtSettings");
    string? issuer = jwtOptions["Issuer"] ?? "";
    string? audience = jwtOptions["Audience"] ?? "";
    string? key = jwtOptions["Key"] ?? "";
    return new JwtHelper(issuer, audience, key);
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "http://localhost:7245/",
            ValidAudience = "http://localhost:7245/",
            IssuerSigningKey =
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes("S132ASDD132DGF89DSFDFGG4789SA3213KKJBDFVV")),
        };
    });
builder.Services.AddCors(options =>
{
    options.AddPolicy(
        "ShopProject - CorsPolicy",
        c =>
        {
            c.AllowAnyOrigin()
                .AllowAnyHeader()
                .WithOrigins("http://localhost:5295")
                .AllowAnyMethod()
                .AllowCredentials()
                .Build();
        }
    );
});

builder.Services.AddDbContext<DataBaseContext>(options =>
    options.UseSqlServer("Server=.;Database=ShopProject;Integrated Security=true;TrustServerCertificate=true"));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("ShopProject - CorsPolicy");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();