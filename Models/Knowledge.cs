using System;
using System.Collections.Generic;

namespace SWD_Project.Models;

public partial class Knowledge
{
    public int KnowledgeId { get; set; }

    public string? Title { get; set; }

    public string? Content { get; set; }

    public string? Status { get; set; }

    public int? TeamId { get; set; }

    public int? TimeLearning { get; set; }

    public string? Visibility { get; set; }

    public string? CreateBy { get; set; }

    public string? UpdateBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual ICollection<Attachment> Attachments { get; set; } = new List<Attachment>();

    public virtual ICollection<KnowledgeConversation> KnowledgeConversations { get; set; } = new List<KnowledgeConversation>();

    public virtual ICollection<KnowledgeHistory> KnowledgeHistories { get; set; } = new List<KnowledgeHistory>();

    public virtual Team? Team { get; set; }
}
