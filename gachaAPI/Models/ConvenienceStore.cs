using System;
using System.Collections.Generic;

namespace gachaAPI.Models;

public partial class ConvenienceStore
{
    public int Id { get; set; }

    public string StoreType { get; set; } = null!;

    public string StoreName { get; set; } = null!;

    public string StoreAddress { get; set; } = null!;

    public int ShippingFee { get; set; }

    public virtual ICollection<ConvenienceStoreInfo> ConvenienceStoreInfos { get; set; } = new List<ConvenienceStoreInfo>();
}
