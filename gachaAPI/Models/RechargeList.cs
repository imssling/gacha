using System;
using System.Collections.Generic;

namespace gachaAPI.Models;

public partial class RechargeList
{
    public int Id { get; set; }

    public int Quantity { get; set; }

    public int Amount { get; set; }

    public string PaymentMode { get; set; } = null!;

    public DateTime? RechargeDate { get; set; }

    public int RechargePlanId { get; set; }

    public int UserId { get; set; }

    public virtual ICollection<PointList> PointLists { get; set; } = new List<PointList>();

    public virtual RechargePlan RechargePlan { get; set; } = null!;

    public virtual UserInfo User { get; set; } = null!;
}
