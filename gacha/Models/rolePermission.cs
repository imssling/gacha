﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace gacha.Models;

public partial class rolePermission
{
    public int roleId { get; set; }

    public int permissionId { get; set; }

    public int? nono { get; set; }

    public virtual permission permission { get; set; }

    public virtual role role { get; set; }
}