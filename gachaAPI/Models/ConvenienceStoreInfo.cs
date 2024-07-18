using System;
using System.Collections.Generic;

namespace gachaAPI.Models;

public partial class ConvenienceStoreInfo
{
    public int Id { get; set; }

    public int StoreId { get; set; }

    public int UserId { get; set; }

    public int ShippingDetailId { get; set; }

    public virtual ShippingDetail ShippingDetail { get; set; } = null!;

    public virtual ConvenienceStore Store { get; set; } = null!;

    public virtual UserInfo User { get; set; } = null!;
}
