﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace gachaAPI.Models;

public partial class Role
{
    public int Id { get; set; }

    public string Title { get; set; }

    public virtual ICollection<Admin> Admins { get; set; } = new List<Admin>();

    public virtual ICollection<Permission> Permissions { get; set; } = new List<Permission>();
}