using System;
using System.Collections.Generic;

namespace gachaAPI.Models;

public partial class GachaTheme
{
    public int Id { get; set; }

    public string ThemeName { get; set; } = null!;

    public bool Status { get; set; }

    public virtual ICollection<GachaMachine> GachaMachines { get; set; } = new List<GachaMachine>();
}
