using System;
using System.Collections.Generic;

namespace gachaAPI.Models;

public partial class ActivityType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<Activity> Activities { get; set; } = new List<Activity>();
}
