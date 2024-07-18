using System;
using System.Collections.Generic;

namespace gachaAPI.Models;

public partial class ChatRoom
{
    public int Id { get; set; }

    public int User1Id { get; set; }

    public int User2Id { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<Message> Messages { get; set; } = new List<Message>();

    public virtual UserInfo User1 { get; set; } = null!;

    public virtual UserInfo User2 { get; set; } = null!;
}
