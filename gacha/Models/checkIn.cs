﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace gacha.Models;

public partial class checkIn
{
    public int id { get; set; }

    public int userID { get; set; }

    public DateTime? checkInDate { get; set; }

    public virtual userInfo user { get; set; }
}