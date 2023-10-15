using UserService.Infrastructure.Extensions;
using System;
using Microsoft.EntityFrameworkCore;
using UserService.Host.Routes;
using UserService.Infrastructure.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;


var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Environment.IsDevelopment() ? builder.Configuration.GetConnectionString("DefaultConnection") : Environment.GetEnvironmentVariable("CONNECTION_STRING");

builder.Services.AddAuthorization();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => ConfigJwtBearerOptions.ConfigureJwtBearerOptions(options));
builder.Services.AddBusinessLogic(builder.Configuration, connectionString!);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.AddAuthRouter();
app.AddUserRouter();
app.AddTodoRouter();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Todo Project");
    options.RoutePrefix = "";
});
    
app.UseHttpsRedirection();

app.Run();
