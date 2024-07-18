﻿using System;
using System.Collections.Generic;

namespace gachaAPI.Models;

public partial class ExchangeRecord
{
    public int Id { get; set; }

    public int? UserIdFrom { get; set; }

    public int? UserIdTo { get; set; }

    public int? GachaIdFrom { get; set; }

    public int? GachaIdTo { get; set; }

    public DateTime? ExchangeDate { get; set; }

    public virtual ICollection<GachaDetailList> GachaDetailLists { get; set; } = new List<GachaDetailList>();

    public virtual GachaProduct? GachaIdFromNavigation { get; set; }

    public virtual GachaProduct? GachaIdToNavigation { get; set; }

    public virtual UserInfo? UserIdFromNavigation { get; set; }

    public virtual UserInfo? UserIdToNavigation { get; set; }
}
