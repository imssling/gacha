﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace gacha.Models;

public partial class UploadRecord
{
    public int Id { get; set; }

    public int BagId { get; set; }

    public int WantProductId { get; set; }

    public DateTime? UploadDate { get; set; }

    public virtual Bag Bag { get; set; }

    public virtual ICollection<GachaDetailList> GachaDetailLists { get; set; } = new List<GachaDetailList>();

    public virtual GachaProduct WantProduct { get; set; }
}