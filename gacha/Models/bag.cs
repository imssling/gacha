﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace gacha.Models;

public partial class bag
{
    public int id { get; set; }

    public DateTime date { get; set; }

    public int userId { get; set; }

    public int gachaProductId { get; set; }

    public string gachaStatus { get; set; }

    public bool isViewed { get; set; }

    public DateTime gachaDate { get; set; }

    public virtual ICollection<gachaDetailList> gachaDetailList { get; set; } = new List<gachaDetailList>();

    public virtual gachaProduct gachaProduct { get; set; }

    public virtual ICollection<pointList> pointList { get; set; } = new List<pointList>();

    public virtual ICollection<shippingDetail> shippingDetail { get; set; } = new List<shippingDetail>();

    public virtual ICollection<uploadRecord> uploadRecord { get; set; } = new List<uploadRecord>();

    public virtual userInfo user { get; set; }
}