﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace gachaAPI.Models;

public partial class GachaTheme
{
    public int Id { get; set; }

    public string ThemeName { get; set; }

    public virtual ICollection<GachaMachine> GachaMachines { get; set; } = new List<GachaMachine>();
}