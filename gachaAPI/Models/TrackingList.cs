using System;
using System.Collections.Generic;

namespace gachaAPI.Models;

public partial class TrackingList
{
    public int UserId { get; set; }

    public int GachaMachineId { get; set; }

    public DateTime? TrackingDate { get; set; }

    public string NoteStatus { get; set; } = null!;

    public virtual GachaMachine GachaMachine { get; set; } = null!;

    public virtual UserInfo User { get; set; } = null!;
}
