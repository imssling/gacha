using System;
using System.Collections.Generic;

namespace gachaAPI.Models;

public partial class Announcement
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Content { get; set; } = null!;

    public string? Image { get; set; }

    public DateTime? CreatedAt { get; set; }
}
