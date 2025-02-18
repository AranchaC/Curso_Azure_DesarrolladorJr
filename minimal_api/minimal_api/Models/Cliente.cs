using System;
using System.Collections.Generic;

namespace minimal_api.Models;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public string? Nombre { get; set; }

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

    public string? Email { get; set; }

    public string? Web { get; set; }

    public string? Comentarios { get; set; }
}
