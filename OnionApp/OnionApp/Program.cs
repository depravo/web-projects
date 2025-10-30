using Microsoft.EntityFrameworkCore;
using OnionApp.Application.Services;
using OnionApp.Core.Interfaces;
using OnionApp.Core.Services;
using OnionApp.Infrastructure.Data;
using OnionApp.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

DotNetEnv.Env.Load();
var server = Environment.GetEnvironmentVariable("DB_SERVER");
var user = Environment.GetEnvironmentVariable("DB_USER");
var password = Environment.GetEnvironmentVariable("DB_PASSWORD");
var dbName = Environment.GetEnvironmentVariable("DB_NAME");
var connectionString = $"server={server};user={user};password={password};database={dbName}";
builder.Services.AddCors(options =>
{
	options.AddPolicy("CorsPolicy", policy =>
	{
		policy.WithOrigins("http://localhost:3000")
			  .AllowAnyMethod()
			  .AllowAnyHeader();
	});
});
builder.Services.AddDbContext<ApplicationDbContext>(options =>
	options.UseMySql(connectionString, new MySqlServerVersion(new Version(9, 4, 0))));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<IEnrollmentRepository, EnrollmentRepository>();
builder.Services.AddScoped<ICourseReviewRepository, CourseReviewRepository>();
builder.Services.AddScoped<IModuleRepository, ModuleRepository>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<IEnrollmentService, EnrollmentService>();
builder.Services.AddScoped<ICourseReviewService, CourseReviewService>();
builder.Services.AddScoped<IModuleService, ModuleService>();

builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();
app.UseCors("CorsPolicy");


if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
