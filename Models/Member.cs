using System;
using System.Collections.Generic;

namespace SWD_Project.Models;

public partial class Member
{
    public int MemberId { get; set; }

    public int? TeamId { get; set; }

    public string? Role { get; set; }

    public int? UserId { get; set; }

    public virtual Team? Team { get; set; }

    public virtual UserAccount? User { get; set; }
}
