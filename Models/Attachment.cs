using System;
using System.Collections.Generic;

namespace SWD_Project.Models;

public partial class Attachment
{
    public int AttachmentId { get; set; }

    public int? KnowledgeId { get; set; }

    public string? FileName { get; set; }

    public string? Url { get; set; }

    public string? CreatedBy { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual Knowledge? Knowledge { get; set; }
}
