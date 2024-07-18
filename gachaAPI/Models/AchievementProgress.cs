using System;
using System.Collections.Generic;

namespace gachaAPI.Models;

public partial class AchievementProgress
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int AchievementId { get; set; }

    public int Progress { get; set; }

    public int Target { get; set; }

    public virtual Achievement Achievement { get; set; } = null!;

    public virtual UserInfo User { get; set; } = null!;
}
