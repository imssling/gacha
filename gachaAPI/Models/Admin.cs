using System;
using System.Collections.Generic;

namespace gachaAPI.Models;

public partial class Admin
{
    public int Id { get; set; }

    public string Account { get; set; } = null!;

    public int RoleId { get; set; }

    public string Email { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual Role Role { get; set; } = null!;
}
