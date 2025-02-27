using System;
using System.Collections.Generic;

namespace WebApi_Concesionario.Models;

public partial class Concesionario
{
    public int Id { get; set; }

    public string Marca { get; set; } = null!;

    public string Modelo { get; set; } = null!;

    public float Precio { get; set; }
    public string Descripcion { get; set; } = null!;
}

