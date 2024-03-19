using System;
using System.Collections.Generic;

namespace SWD_Project.Models;

public partial class KnowledgeHistory
{
    public int HistoryId { get; set; }

    public string? Content { get; set; }

    public int? KnowledgeId { get; set; }

    public int? UserProfileId { get; set; }

    public string? CreatedBy { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual Knowledge? Knowledge { get; set; }
}
