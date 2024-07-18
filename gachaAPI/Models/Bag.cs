using System;
using System.Collections.Generic;

namespace gachaAPI.Models;

public partial class Bag
{
    public int Id { get; set; }

    public DateTime Date { get; set; }

    public int UserId { get; set; }

    public int GachaProductId { get; set; }

    public string GachaStatus { get; set; } = null!;

    public virtual ICollection<GachaDetailList> GachaDetailLists { get; set; } = new List<GachaDetailList>();

    public virtual GachaProduct GachaProduct { get; set; } = null!;

    public virtual ICollection<PointList> PointLists { get; set; } = new List<PointList>();

    public virtual ICollection<ShippingDetail> ShippingDetails { get; set; } = new List<ShippingDetail>();

    public virtual ICollection<UploadRecord> UploadRecords { get; set; } = new List<UploadRecord>();

    public virtual UserInfo User { get; set; } = null!;
}
