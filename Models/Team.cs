using System;
using System.Collections.Generic;

namespace SWD_Project.Models;

public partial class Team
{
    public int TeamId { get; set; }

    public string? Name { get; set; }

    public string? Po { get; set; }

    public int? TotalMember { get; set; }

    public string? Description { get; set; }

    public string? Status { get; set; }

    public int? TotalKnowledge { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual ICollection<Knowledge> Knowledges { get; set; } = new List<Knowledge>();

    public virtual ICollection<Member> Members { get; set; } = new List<Member>();

    public virtual ICollection<TeamRequest> TeamRequests { get; set; } = new List<TeamRequest>();
}
