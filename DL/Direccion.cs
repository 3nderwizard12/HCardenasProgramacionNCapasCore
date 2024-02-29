using System;
using System.Collections.Generic;

namespace DL;

public partial class Direccion
{
    public int IdDireccion { get; set; }

    public string Calle { get; set; } = null!;

    public string? NumeroInterios { get; set; }

    public string Numeroexterior { get; set; } = null!;

    public int IdColonia { get; set; }

    public string NombreColonia { get; set; } = null!;

    public int IdUsuario { get; set; }

    public string NombreUsuario { get; set; } = null!;

    public string ApellidoPaterno { get; set; } = null!;

    public string ApellidoMaterno { get; set; } = null!;

    public virtual Colonium IdColoniaNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
