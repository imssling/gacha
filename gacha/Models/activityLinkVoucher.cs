﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace gacha.Models;

public partial class activityLinkVoucher
{
    public int id { get; set; }

    public int activityID { get; set; }

    public int voucherID { get; set; }

    public virtual activity activity { get; set; }

    public virtual voucher voucher { get; set; }
}