using System;
using System.Collections.Generic;

namespace Registro.Models;

public partial class Docente
{
    public int IdDocente { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public DateOnly? FechaNacimiento { get; set; }

    public string? TituloAcademico { get; set; }

    public decimal Salario { get; set; }

    public DateOnly FechaContratacion { get; set; }

    public string? CorreoElectronico { get; set; }

    public string? NumeroTelefono { get; set; }
}
