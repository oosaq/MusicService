using KartoshkaEvent.Api;
using KartoshkaEvent.Application;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using MusicService.Database;
using MusicService.JwtProvider;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
var configuration = builder.Configuration;

services
    .AddApplicationLayer()
    .AddDataAccess(configuration)
    .AddJwtProvider();

services.AddControllers();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.Events = new JwtBearerEvents
    {
        OnMessageReceived = context =>
        {
            if (context.Request.Cookies.TryGetValue("access", out var token))
            {
                context.Token = token;
            }
            return Task.CompletedTask;
        }
    };


    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
        configuration["JwtSettings:SecretKey"]!
    ))

    };

});


services.AddAuthorization();

builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen();

builder.Services.AddCors(conf =>
{
    conf.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
        policy.AllowAnyOrigin();
    });
});


var app = builder.Build();

app.UseAuthentication();

app.UseRouting();

app.UseCors("AllowAll");

app.UseAuthorization();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(opt =>
    {
        opt.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        opt.RoutePrefix = string.Empty;
    });
}

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<MusicServiceContext>();
    await DbInitializer.Initialize(context);
}

app.UseStaticFiles();

app.MapControllers();

app.Run();