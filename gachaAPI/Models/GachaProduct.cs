using System;
using System.Collections.Generic;

namespace gachaAPI.Models;

public partial class GachaProduct
{
    public int Id { get; set; }

    public int MachineId { get; set; }

    public string ProductName { get; set; } = null!;

    public int Stock { get; set; }

    public string ProductPictureName { get; set; } = null!;

    public DateTime? CreateTime { get; set; }

    public virtual ICollection<Bag> Bags { get; set; } = new List<Bag>();

    public virtual ICollection<ExchangeRecord> ExchangeRecordGachaIdFromNavigations { get; set; } = new List<ExchangeRecord>();

    public virtual ICollection<ExchangeRecord> ExchangeRecordGachaIdToNavigations { get; set; } = new List<ExchangeRecord>();

    public virtual GachaMachine Machine { get; set; } = null!;
}
