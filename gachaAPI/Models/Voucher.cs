using System;
using System.Collections.Generic;

namespace gachaAPI.Models;

public partial class Voucher
{
    public int Id { get; set; }

    public string VoucherName { get; set; } = null!;

    public string VoucherCode { get; set; } = null!;

    public string? VoucherDescription { get; set; }

    public int Duration { get; set; }

    public virtual ICollection<ActivityLinkVoucher> ActivityLinkVouchers { get; set; } = new List<ActivityLinkVoucher>();

    public virtual ICollection<UserVoucher> UserVouchers { get; set; } = new List<UserVoucher>();
}
