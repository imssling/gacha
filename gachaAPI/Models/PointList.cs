﻿using System;
using System.Collections.Generic;

namespace gachaAPI.Models;

public partial class PointList
{
    public int Id { get; set; }

    public int? RechargeListId { get; set; }

    public int? BagId { get; set; }

    public int? AchievementId { get; set; }

    public virtual Achievement? Achievement { get; set; }

    public virtual Bag? Bag { get; set; }

    public virtual RechargeList? RechargeList { get; set; }
}
