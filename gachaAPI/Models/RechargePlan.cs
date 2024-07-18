using System;
using System.Collections.Generic;

namespace gachaAPI.Models;

public partial class RechargePlan
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public int Point { get; set; }

    public int Price { get; set; }

    public bool Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<RechargeList> RechargeLists { get; set; } = new List<RechargeList>();
}
