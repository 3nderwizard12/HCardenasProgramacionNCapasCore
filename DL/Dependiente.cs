using System;
using System.Collections.Generic;

namespace DL;

public partial class Dependiente
{
    public int IdDependiente { get; set; }

    public string NumeroEmpleado { get; set; } = null!;

    public string NombreEmpleado { get; set; } = null!;

    public string ApellidoPaternoEmpleado { get; set; } = null!;

    public string ApelldioMaternoEmpleado { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string ApellidoPaterno { get; set; } = null!;

    public string ApellidoMaterno { get; set; } = null!;

    public DateTime? FechaNacimiento { get; set; }

    public string? EstadoCivil { get; set; }

    public string Genero { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string Rfc { get; set; } = null!;

    public int IdDependienteTipo { get; set; }

    public string NombreDependienteTipo { get; set; } = null!;

    public virtual DependienteTipo IdDependienteTipoNavigation { get; set; } = null!;

    public virtual Empleado NumeroEmpleadoNavigation { get; set; } = null!;
}
