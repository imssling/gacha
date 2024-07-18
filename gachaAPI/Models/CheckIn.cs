using System;
using System.Collections.Generic;

namespace gachaAPI.Models;

public partial class CheckIn
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public DateTime? CheckInDate { get; set; }

    public virtual UserInfo User { get; set; } = null!;
}
