﻿using System;
using System.Collections.Generic;

namespace gachaAPI.Models;

public partial class RolePermission
{
    public int RoleId { get; set; }

    public int PermissionId { get; set; }

    public int? Nono { get; set; }

    public virtual Permission Permission { get; set; } = null!;

    public virtual Role Role { get; set; } = null!;
}
