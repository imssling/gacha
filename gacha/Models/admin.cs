﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace gacha.Models;

public partial class admin
{
    public string account { get; set; }

    public string name { get; set; }

    public int roleId { get; set; }

    public string email { get; set; }

    public string phoneNumber { get; set; }

    public string password { get; set; }

    public virtual role role { get; set; }
}