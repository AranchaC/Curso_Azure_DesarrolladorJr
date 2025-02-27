using Microsoft.EntityFrameworkCore;
using WebApi_Concesionario.Interfaces;
using WebApi_Concesionario.Models;
using WebApi_Concesionario.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//para conectar con la BBDD
//Dónde obtengo el string de conexión con la BBDD
builder.Services.AddDbContext<ConcesionarioDbContext>(option =>
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//implementa el servicio: la interfaz de este servicio.
builder.Services.AddScoped<ICRUD<Concesionario>, ConcesionarioService>();

//Configurar CORS para el acceso total al servicio
builder.Services.AddCors(option =>
{
    option.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
