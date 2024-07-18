﻿using System;
using System.Collections.Generic;

namespace gachaAPI.Models;

public partial class UploadRecord
{
    public int Id { get; set; }

    public int BagId { get; set; }

    public DateTime? UploadDate { get; set; }

    public virtual Bag Bag { get; set; } = null!;

    public virtual ICollection<GachaDetailList> GachaDetailLists { get; set; } = new List<GachaDetailList>();
}
