using System;
using System.Collections.Generic;

namespace gachaAPI.Models;

public partial class UserVoucher
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int VoucherId { get; set; }

    public int Quantity { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public virtual UserInfo User { get; set; } = null!;

    public virtual Voucher Voucher { get; set; } = null!;
}
