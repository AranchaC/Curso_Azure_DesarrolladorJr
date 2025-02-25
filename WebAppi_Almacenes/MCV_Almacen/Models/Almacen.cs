using System;
using System.Collections.Generic;

namespace WebAppi_Almacenes.Models;

public partial class Almacen
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Ubicacion { get; set; } = null!;

    public int Capacidad { get; set; }
}

