﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace gacha.Models;

public partial class permission
{
    public int id { get; set; }

    public string permissionDesc { get; set; }

    public virtual ICollection<role> role { get; set; } = new List<role>();
}