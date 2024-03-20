using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SWD_Project.Models;

public partial class Swd392Context : DbContext
{
    public Swd392Context()
    {
    }

    public Swd392Context(DbContextOptions<Swd392Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Attachment> Attachments { get; set; }

    public virtual DbSet<Knowledge> Knowledges { get; set; }

    public virtual DbSet<KnowledgeConversation> KnowledgeConversations { get; set; }

    public virtual DbSet<KnowledgeHistory> KnowledgeHistories { get; set; }

    public virtual DbSet<Member> Members { get; set; }

    public virtual DbSet<Team> Teams { get; set; }

    public virtual DbSet<TeamRequest> TeamRequests { get; set; }

    public virtual DbSet<UserAccount> UserAccounts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-432H1T56;Initial Catalog=SWD392;User ID=sa;Password=123;encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Attachment>(entity =>
        {
            entity.HasKey(e => e.AttachmentId).HasName("PK__Attachme__442C64BEB135886C");

            entity.ToTable("Attachment");

            entity.Property(e => e.AttachmentId).ValueGeneratedNever();
            entity.Property(e => e.CreatedBy).HasMaxLength(100);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.FileName).HasMaxLength(255);
            entity.Property(e => e.UpdatedBy).HasMaxLength(100);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Knowledge).WithMany(p => p.Attachments)
                .HasForeignKey(d => d.KnowledgeId)
                .HasConstraintName("FK_Attachment_Knowledge");
        });

        modelBuilder.Entity<Knowledge>(entity =>
        {
            entity.HasKey(e => e.KnowledgeId).HasName("PK__Knowledg__FF28F849D35F68F4");

            entity.ToTable("Knowledge");

            entity.Property(e => e.KnowledgeId).ValueGeneratedNever();
            entity.Property(e => e.CreateBy).HasMaxLength(100);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.Title).HasMaxLength(255);
            entity.Property(e => e.UpdateBy).HasMaxLength(100);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.Visibility).HasMaxLength(50);

            entity.HasOne(d => d.Team).WithMany(p => p.Knowledges)
                .HasForeignKey(d => d.TeamId)
                .HasConstraintName("FK_Knowledge_Team");
        });

        modelBuilder.Entity<KnowledgeConversation>(entity =>
        {
            entity.HasKey(e => e.KnowledgeConversationId).HasName("PK__Knowledg__DD60FA8A276CA7EA");

            entity.ToTable("KnowledgeConversation");

            entity.Property(e => e.KnowledgeConversationId).ValueGeneratedNever();
            entity.Property(e => e.CreatedBy).HasMaxLength(100);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedBy).HasMaxLength(100);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Knowledge).WithMany(p => p.KnowledgeConversations)
                .HasForeignKey(d => d.KnowledgeId)
                .HasConstraintName("FK_KnowledgeConversation_Knowledge");
        });

        modelBuilder.Entity<KnowledgeHistory>(entity =>
        {
            entity.HasKey(e => e.HistoryId).HasName("PK__Knowledg__4D7B4ABDDF9C4221");

            entity.ToTable("KnowledgeHistory");

            entity.Property(e => e.HistoryId).ValueGeneratedNever();
            entity.Property(e => e.CreatedBy).HasMaxLength(100);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedBy).HasMaxLength(100);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Knowledge).WithMany(p => p.KnowledgeHistories)
                .HasForeignKey(d => d.KnowledgeId)
                .HasConstraintName("FK_KnowledgeHistory_Knowledge");
        });

        modelBuilder.Entity<Member>(entity =>
        {
            entity.HasKey(e => e.MemberId).HasName("PK__Member__0CF04B18BAD2506F");

            entity.ToTable("Member");

            entity.Property(e => e.MemberId).ValueGeneratedNever();
            entity.Property(e => e.Role).HasMaxLength(20);

            entity.HasOne(d => d.Team).WithMany(p => p.Members)
                .HasForeignKey(d => d.TeamId)
                .HasConstraintName("FK_Member_Team");

            entity.HasOne(d => d.User).WithMany(p => p.Members)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Member_UserAccount");
        });

        modelBuilder.Entity<Team>(entity =>
        {
            entity.HasKey(e => e.TeamId).HasName("PK__Team__123AE79997A15C62");

            entity.ToTable("Team");

            entity.Property(e => e.TeamId).ValueGeneratedNever();
            entity.Property(e => e.CreatedBy).HasMaxLength(100);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Po)
                .HasMaxLength(20)
                .HasColumnName("PO");
            entity.Property(e => e.Status).HasMaxLength(20);
            entity.Property(e => e.UpdatedBy).HasMaxLength(100);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<TeamRequest>(entity =>
        {
            entity.HasKey(e => e.RequestId).HasName("PK__TeamRequ__33A8517AC878C2F7");

            entity.ToTable("TeamRequest");

            entity.Property(e => e.RequestId).ValueGeneratedNever();
            entity.Property(e => e.CreatedBy).HasMaxLength(100);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.UpdatedBy).HasMaxLength(100);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Team).WithMany(p => p.TeamRequests)
                .HasForeignKey(d => d.TeamId)
                .HasConstraintName("FK_TeamRequest_Team");
        });

        modelBuilder.Entity<UserAccount>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__UserAcco__1788CC4C133E620A");

            entity.ToTable("UserAccount");

            entity.HasIndex(e => e.Username, "UQ__UserAcco__536C85E4C20C3A97").IsUnique();

            entity.HasIndex(e => e.Password, "UQ__UserAcco__87909B156B89C7E0").IsUnique();

            entity.Property(e => e.UserId).ValueGeneratedNever();
            entity.Property(e => e.Password).HasMaxLength(100);
            entity.Property(e => e.Role).HasMaxLength(20);
            entity.Property(e => e.Status).HasMaxLength(20);
            entity.Property(e => e.Username).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
