using System;
using System.Collections.Generic;

namespace SWD_Project.Models;

public partial class UserAccount
{
    public int UserId { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? Role { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<Member> Members { get; set; } = new List<Member>();
}
