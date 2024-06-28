﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace szAPI.Models;

public partial class Activity
{
    public int Id { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public bool Status { get; set; }

    public int ActivityTypeId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? ActivityStart { get; set; }

    public DateTime? ActivityEnd { get; set; }

    public virtual ICollection<ActivityLinkVoucher> ActivityLinkVouchers { get; set; } = new List<ActivityLinkVoucher>();

    public virtual ActivityType ActivityType { get; set; }
}