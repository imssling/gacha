﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace gacha.Models;

public partial class convenienceStore
{
    public int id { get; set; }

    public string storeType { get; set; }

    public string storeName { get; set; }

    public string storeAddress { get; set; }

    public int shippingFee { get; set; }

    public virtual ICollection<convenienceStoreInfo> convenienceStoreInfo { get; set; } = new List<convenienceStoreInfo>();
}