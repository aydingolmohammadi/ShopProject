using System.Text;
using Application.Contracts;
using Application.Services;
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

// builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//     .AddJwtBearer(options =>
//     {
//         options.TokenValidationParameters = new TokenValidationParameters
//         {
//             ValidateIssuer = true,
//             ValidateAudience = true,
//             ValidateLifetime = true,
//             ValidIssuer = "http://localhost:5295",
//             IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("shopProject - secret"))
//         };
//     });
// builder.Services.AddCors(options =>
// {
//     options.AddPolicy(
//         "CorsPolicy",
//         c =>
//         {
//             c.AllowAnyOrigin().AllowAnyHeader().WithOrigins(
//                 "http://localhost:5295"
//             ).AllowAnyMethod().AllowCredentials();
//         }
//     );
// });

builder.Services.AddDbContext<DataBaseContext>(options =>
    options.UseSqlServer("Server=.;Database=ShopProject;Integrated Security=true;TrustServerCertificate=true"));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseCors("CorsPolicy");
// app.UseAuthentication();

app.MapControllers();

app.Run();