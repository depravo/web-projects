using ApiProject.Model;
using CreateDBProj;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;
using System;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
//string connection = builder.Configuration.GetConnectionString("DefaultConnection");
DotNetEnv.Env.Load();
var server = Environment.GetEnvironmentVariable("DB_SERVER");
var user = Environment.GetEnvironmentVariable("DB_USER");
var password = Environment.GetEnvironmentVariable("DB_PASSWORD");
var dbName = Environment.GetEnvironmentVariable("DB_NAME");
var connectionString = $"server={server};user={user};password={password};database={dbName}";
builder.Services.AddDbContext<ApplicationContext>(options => options.UseMySql(connectionString, new MySqlServerVersion(new Version(9, 4, 0))));
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment()) {
	app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
