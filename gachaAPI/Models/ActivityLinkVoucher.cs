﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace gachaAPI.Models;

public partial class ActivityLinkVoucher
{
    public int Id { get; set; }

    public int ActivityId { get; set; }

    public int VoucherId { get; set; }

    public virtual Activity Activity { get; set; }

    public virtual Voucher Voucher { get; set; }
}