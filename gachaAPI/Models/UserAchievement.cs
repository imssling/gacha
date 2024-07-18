using System;
using System.Collections.Generic;

namespace gachaAPI.Models;

public partial class UserAchievement
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int AchievementId { get; set; }

    public DateTime? AchievedAt { get; set; }

    public virtual Achievement Achievement { get; set; } = null!;

    public virtual UserInfo User { get; set; } = null!;
}
