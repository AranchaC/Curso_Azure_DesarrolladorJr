using System;
using System.Collections.Generic;

namespace WebApp_Asistentes.Models;

public partial class Asistente
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public int? Edad { get; set; }
}
