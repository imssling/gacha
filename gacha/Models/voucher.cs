﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace gacha.Models;

public partial class Voucher
{
    public int Id { get; set; }

    public string VoucherName { get; set; }

    public string VoucherCode { get; set; }

    public string VoucherDescription { get; set; }

    public int Duration { get; set; }

    public virtual ICollection<ActivityLinkVoucher> ActivityLinkVouchers { get; set; } = new List<ActivityLinkVoucher>();

    public virtual ICollection<UserVoucher> UserVouchers { get; set; } = new List<UserVoucher>();
}