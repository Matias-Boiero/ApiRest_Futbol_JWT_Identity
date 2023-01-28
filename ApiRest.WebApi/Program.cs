using ApiRest.Abstracciones;
using ApiRest.AccesoDatos;
using ApiRest.Aplicacion;
using ApiRest.Repositorio;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Traigo el servicio del repositorio generico, el typeof es para que se identifique
//el tipo de objeto para la iyeccion de dependencia

builder.Services.AddScoped(typeof(IAplicacion<>), typeof(Aplicacion<>));
builder.Services.AddScoped(typeof(IRepositorio<>), typeof(Repositorio<>));
builder.Services.AddScoped(typeof(IDbContext<>), typeof(DbContext<>));

//c => c.MigrationsAssembly("ApiRest.WebApi") para que me guarde las migraciones desde la capa de AccesoDatos a el assembly de WebApi
builder.Services.AddDbContext<ApiDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), c => c.MigrationsAssembly("ApiRest.WebApi")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
