using System;
using System.Collections.Generic;

namespace DL;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string UserName { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string ApellidoPaterno { get; set; } = null!;

    public string ApellidoMaterno { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Sexo { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string Celular { get; set; } = null!;

    public DateTime FechaNacimiento { get; set; }

    public string Curp { get; set; } = null!;

    public string? Image { get; set; }

    public byte IdRole { get; set; }

    public string NombreRole { get; set; } = null!;

    public bool? Estatus { get; set; }

    public int IdDireccion { get; set; }

    public string Calle { get; set; } = null!;

    public string NumeroInterios { get; set; } = null!;

    public string Numeroexterior { get; set; } = null!;

    public int IdColonia { get; set; }

    public string NombreColonia { get; set; } = null!;

    public int IdMunicipio { get; set; }

    public string NombreMunicipio { get; set; } = null!;

    public int IdEstado { get; set; }

    public string NombreEstado { get; set; } = null!;

    public int IdPais { get; set; }

    public string NombrePais { get; set; } = null!;

    public virtual ICollection<Aseguradora> Aseguradoras { get; set; } = new List<Aseguradora>();

    public virtual ICollection<Direccion> Direccions { get; set; } = new List<Direccion>();

    public virtual Role IdRoleNavigation { get; set; } = null!;

    public virtual ICollection<Poliza> Polizas { get; set; } = new List<Poliza>();
}
