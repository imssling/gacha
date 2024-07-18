using System;
using System.Collections.Generic;

namespace gachaAPI.Models;

public partial class ActivityLinkVoucher
{
    public int Id { get; set; }

    public int ActivityId { get; set; }

    public int VoucherId { get; set; }

    public virtual Activity Activity { get; set; } = null!;

    public virtual Voucher Voucher { get; set; } = null!;
}
