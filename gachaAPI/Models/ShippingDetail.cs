using System;
using System.Collections.Generic;

namespace gachaAPI.Models;

public partial class ShippingDetail
{
    public int Id { get; set; }

    public int ShippingId { get; set; }

    public int BagId { get; set; }

    public virtual Bag Bag { get; set; } = null!;

    public virtual ICollection<ConvenienceStoreInfo> ConvenienceStoreInfos { get; set; } = new List<ConvenienceStoreInfo>();

    public virtual ICollection<GachaDetailList> GachaDetailLists { get; set; } = new List<GachaDetailList>();

    public virtual Shipping Shipping { get; set; } = null!;
}
