using System;
using System.Collections.Generic;

namespace gachaAPI.Models;

public partial class Permission
{
    public int Id { get; set; }

    public string PermissionDesc { get; set; } = null!;

    public virtual ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
}
