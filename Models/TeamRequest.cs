using System;
using System.Collections.Generic;

namespace SWD_Project.Models;

public partial class TeamRequest
{
    public int RequestId { get; set; }

    public int? UserId { get; set; }

    public int? TeamId { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? Status { get; set; }

    public virtual Team? Team { get; set; }
}
