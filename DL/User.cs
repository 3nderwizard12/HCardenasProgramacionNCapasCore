using System;
using System.Collections.Generic;

namespace DL;

public partial class User
{
    public int IdUser { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string MotherLastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string PostalCode { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public DateTime Birthday { get; set; }

    public string Gender { get; set; } = null!;

    public string MobileNumber { get; set; } = null!;

    public string Curp { get; set; } = null!;

    public string Image { get; set; } = null!;

    public byte IdRole { get; set; }

    public virtual Role IdRoleNavigation { get; set; } = null!;
}
