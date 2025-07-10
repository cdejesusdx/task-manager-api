using InsolTech.TaskManager.Api.Middlewares; 
using InsolTech.TaskManager.Application.Extensions;
using InsolTech.TaskManager.Application.Mapping;
using InsolTech.TaskManager.Infrastructure.Data;
using InsolTech.TaskManager.Infrastructure.Extensions;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// ==========================
// DEPENDENCIAS
// ==========================
builder.Services.AddControllers();

builder.Services.AddApplication();      
builder.Services.AddInfrastructure();
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddTransient<ErrorHandlingMiddleware>();

// ==========================
// CORS para Angular
// ==========================
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular",
        policy => policy.WithOrigins("http://localhost:4200")
                        .AllowAnyHeader()
                        .AllowAnyMethod());
});

// ==========================
// Swagger / OpenAPI
// ==========================
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Task Manager API",
        Version = "v1",
        Description = "API para gestión de tareas con .NET + Angular"
    });
});

var app = builder.Build();

// =======================
// SEEDING DE DATOS INICIALES
// =======================
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<TaskDbContext>();
    DbInitializer.Seed(context);
}

// ==========================
// MIDDLEWARES
// ==========================
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ErrorHandlingMiddleware>(); 

app.UseHttpsRedirection();

app.UseCors("AllowAngular");

app.UseAuthorization();

app.MapControllers();

app.Run();