﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace gacha.Models;

public partial class rechargeList
{
    public string id { get; set; }

    public int quantity { get; set; }

    public int amount { get; set; }

    public string paymentMode { get; set; }

    public DateTime? rechargeDate { get; set; }

    public int rechargePlanId { get; set; }

    public int userId { get; set; }

    public virtual ICollection<pointList> pointList { get; set; } = new List<pointList>();

    public virtual rechargePlan rechargePlan { get; set; }

    public virtual userInfo user { get; set; }
}