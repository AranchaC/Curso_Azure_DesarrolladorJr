using minimal_api.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

VentasCorporativasDbContext context = new VentasCorporativasDbContext();

app.MapGet("/ListarClientes", () =>
{
    return context.Clientes.ToList();
});

app.MapGet("/ClientePorId/{id}", (int id) =>
{
    return context.Clientes.Find(id);
});

app.MapGet("/ClientePorNombre/{nombre}", (string nombre) =>
{
    return context.Clientes.Where(cli => cli.Nombre == nombre).ToList();
});

app.MapPost("/AgregarCliente/", (Cliente cliente) =>
{
    bool estado = false;
    try
    {
        context.Clientes.Add(cliente);
        context.SaveChanges();
        estado = true;
    }
    catch { }
    return estado;
});

app.Run();


