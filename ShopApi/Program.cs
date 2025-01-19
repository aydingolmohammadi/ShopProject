using System.Text;
using ShopProject.Application;
using ShopProject.Application.Contracts;
using ShopProject.Application.Services;
using Infrastructure;
using Infrastructure.repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

var config = builder.Configuration.GetSection("JwtSettings").Get<Config>();
builder.Services.AddSingleton(config);
builder.Services.AddSingleton<TokenGenerator>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = config.Issuer,
            ValidAudience = config.Audience,
            IssuerSigningKey =
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.Key)),
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
                .WithOrigins(config.Issuer)
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