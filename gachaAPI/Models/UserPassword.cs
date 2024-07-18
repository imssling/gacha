using System;
using System.Collections.Generic;

namespace gachaAPI.Models;

public partial class UserPassword
{
    public string Email { get; set; } = null!;

    public string UserPassword1 { get; set; } = null!;
}
