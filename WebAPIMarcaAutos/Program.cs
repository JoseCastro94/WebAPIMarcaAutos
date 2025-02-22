using Microsoft.EntityFrameworkCore;
using System;
using WebAPIMarcaAutos.Config;
using WebAPIMarcaAutos.Repositories;
using WebAPIMarcaAutos.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configuración de servicios y repositorios
builder.Services.AddScoped<IMarcasAutosRepository, MarcasAutosRepository>();
builder.Services.AddScoped<IMarcasAutosService, MarcasAutosService>();

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.Use(async (context, next) => {
    if (context.Request.Path == "/")
    {
        context.Response.Redirect("/swagger/index.html", permanent: false);
        return;
    }
    await next();
});


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI();
    app.UseSwagger();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
