﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace gachaAPI.Models;

public partial class ConvenienceStore
{
    public int Id { get; set; }

    public string StoreType { get; set; }

    public string StoreName { get; set; }

    public string StoreAddress { get; set; }

    public int ShippingFee { get; set; }

    public virtual ICollection<ConvenienceStoreInfo> ConvenienceStoreInfos { get; set; } = new List<ConvenienceStoreInfo>();
}