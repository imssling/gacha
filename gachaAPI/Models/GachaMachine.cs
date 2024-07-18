using System;
using System.Collections.Generic;

namespace gachaAPI.Models;

public partial class GachaMachine
{
    public int Id { get; set; }

    public int ThemeId { get; set; }

    public string MachineName { get; set; } = null!;

    public string? MachineDescription { get; set; }

    public string MachinePictureName { get; set; } = null!;

    public DateTime? CreateTime { get; set; }

    public int Price { get; set; }

    public bool Status { get; set; }

    public virtual ICollection<GachaProduct> GachaProducts { get; set; } = new List<GachaProduct>();

    public virtual GachaTheme Theme { get; set; } = null!;

    public virtual ICollection<TrackingList> TrackingLists { get; set; } = new List<TrackingList>();
}
