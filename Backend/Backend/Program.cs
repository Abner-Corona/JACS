
using Core.Interfaces.Repositorios;
using Core.Interfaces.Servicios;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using RepositorioEntityCore;
using Servicios;
using System.IO.Compression;
var builder = WebApplication.CreateBuilder(args);
var DatabaseName = "TestBD";
  var CorsAll = "Todos";

// Add services to the container.

builder.Services.AddControllers();

//Conexion ala bd en sql lite
//builder.Services.AddDbContext<_Contexto>(opt => opt.UseLazyLoadingProxies()
//                        .UseInMemoryDatabase(databaseName: "Test")
//                        .ConfigureWarnings(w => w.Ignore(CoreEventId.LazyLoadOnDisposedContextWarning))
//                        .ConfigureWarnings(warnings => warnings.Ignore(CoreEventId.DetachedLazyLoadingWarning)));
if (!Directory.Exists(DatabaseName))
{
    Directory.CreateDirectory(DatabaseName);
}
builder.Services.AddDbContext<_Contexto>(opt => opt.UseLazyLoadingProxies().UseSqlite(new SqliteConnection($"Data Source={DatabaseName}/data.db")));

builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();
builder.Services.AddScoped<IServicioUsuario, ServicioUsuario>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddCors(options =>
{
    options.AddPolicy(CorsAll,
    builder =>
    {

        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors(CorsAll);

app.UseAuthorization();

app.MapControllers();

app.Run();
