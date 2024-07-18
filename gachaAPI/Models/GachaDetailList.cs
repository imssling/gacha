using System;
using System.Collections.Generic;

namespace gachaAPI.Models;

public partial class GachaDetailList
{
    public int Id { get; set; }

    public int? BagId { get; set; }

    public int? ExchangeRecordId { get; set; }

    public int? UploadRecordId { get; set; }

    public int? ShippingDetailId { get; set; }

    public virtual Bag? Bag { get; set; }

    public virtual ExchangeRecord? ExchangeRecord { get; set; }

    public virtual ShippingDetail? ShippingDetail { get; set; }

    public virtual UploadRecord? UploadRecord { get; set; }
}
