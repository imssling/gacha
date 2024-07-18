using System;
using System.Collections.Generic;

namespace gachaAPI.Models;

public partial class Activity
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public bool Status { get; set; }

    public int ActivityTypeId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? ActivityStart { get; set; }

    public DateTime? ActivityEnd { get; set; }

    public virtual ICollection<ActivityLinkVoucher> ActivityLinkVouchers { get; set; } = new List<ActivityLinkVoucher>();

    public virtual ActivityType ActivityType { get; set; } = null!;
}
