﻿using System;
using System.Collections.Generic;

namespace gachaAPI.Models;

public partial class Achievement
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string? AchievementType { get; set; }

    public int Target { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<AchievementProgress> AchievementProgresses { get; set; } = new List<AchievementProgress>();

    public virtual ICollection<PointList> PointLists { get; set; } = new List<PointList>();

    public virtual ICollection<UserAchievement> UserAchievements { get; set; } = new List<UserAchievement>();
}
