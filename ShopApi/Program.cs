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
builder.Services.AddSwaggerGen(
    o => {
        o.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
        {
            Description = @"JWT Authorization header using the Bearer scheme. 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      Example: 'Bearer $token'",
            Name = "Authorization",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer"
        });

        o.AddSecurityRequirement(new OpenApiSecurityRequirement()
        {
            {
                new OpenApiSecurityScheme()
                {
                    Reference = new OpenApiReference()
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    },
                    Scheme = "oauth2",
                    Name = "Bearer",
                    In = ParameterLocation.Header
                },
                new List<string>()
            }
        });

        o.SwaggerDoc("v1",new OpenApiInfo()
        {
            Version = "v1",
            Title = "Shop project"
        });
}
);

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

# region <Auth>

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = "http://localhost:5295",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ShopProject - secret")),
            ValidateIssuerSigningKey = true,
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

# endregion

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

app.MapControllers();

app.Run();