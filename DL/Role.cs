using System;
using System.Collections.Generic;

namespace DL;

public partial class Role
{
    public byte IdRole { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
