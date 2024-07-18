using System;
using System.Collections.Generic;

namespace gachaAPI.Models;

public partial class Message
{
    public int Id { get; set; }

    public int ChatRoomId { get; set; }

    public int SenderId { get; set; }

    public string? Content { get; set; }

    public DateTime? SendDate { get; set; }

    public virtual ChatRoom ChatRoom { get; set; } = null!;

    public virtual UserInfo Sender { get; set; } = null!;
}
