using System;
using System.Collections.Generic;

namespace gachaAPI.Models;

public partial class Shipping
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public DateTime? ShippingDate { get; set; }

    public string ShippingStatus { get; set; } = null!;

    public string ShippingAddress { get; set; } = null!;

    public string ContactPhone { get; set; } = null!;

    public string ShippingMethod { get; set; } = null!;

    public int ShippingFee { get; set; }

    public virtual ICollection<ShippingDetail> ShippingDetails { get; set; } = new List<ShippingDetail>();

    public virtual UserInfo User { get; set; } = null!;
}
