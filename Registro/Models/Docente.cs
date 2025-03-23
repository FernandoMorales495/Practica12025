using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Registro.Models;

public partial class Docente
{
    public int IdDocente { get; set; }
    [Required(ErrorMessage = "El nombre del docente obligatorio.")]
    public string Nombre { get; set; } = null!;
    [Required(ErrorMessage = "El apellido del docente es obligatorio.")]
    public string Apellido { get; set; } = null!;
    [Display(Name = "Fecha de nacimiento")]
    public DateOnly? FechaNacimiento { get; set; }
    [Display(Name = "Titulo academico")]
    public string? TituloAcademico { get; set; }
    [Required(ErrorMessage = "El salario es obligatorio.")]
    public decimal Salario { get; set; }
    [Required(ErrorMessage = "La fecha de contratacion es obligatoria.")]
    [Display(Name = "Fecha de contratacion")]
    public DateOnly FechaContratacion { get; set; }
    [Display(Name = "Correo electronico")]
    public string? CorreoElectronico { get; set; }
    [Display(Name = "Numero de telefono")]
    public string? NumeroTelefono { get; set; }
}
