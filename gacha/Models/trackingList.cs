﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace gacha.Models;

public partial class trackingList
{
    public int userId { get; set; }

    public int gachaMachineId { get; set; }

    public DateTime? trackingDate { get; set; }

    public string noteStatus { get; set; }

    public virtual gachaMachine gachaMachine { get; set; }

    public virtual userInfo user { get; set; }
}