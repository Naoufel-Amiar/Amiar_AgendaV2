using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Amiar_Agenda.AgendaDB;

public partial class AgendaContext : DbContext
{
    public AgendaContext()
    {
    }

    public AgendaContext(DbContextOptions<AgendaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<SocialMedium> SocialMedia { get; set; }

    public virtual DbSet<SocialProfil> SocialProfils { get; set; }

    public virtual DbSet<Tache> Taches { get; set; }

    public virtual DbSet<ToDoList> ToDoLists { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=172.31.254.161;port=3306;user=slab58;password=2005;database=agenda", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.11.6-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Contact>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("contact");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Adress).HasMaxLength(45);
            entity.Property(e => e.Nom).HasMaxLength(45);
            entity.Property(e => e.Prenom).HasMaxLength(45);
            entity.Property(e => e.Sex).HasColumnType("enum('H','F')");
            entity.Property(e => e.Status).HasColumnType("enum('Friends','Familly','Knowing','Work')");
            entity.Property(e => e.Tel).HasMaxLength(45);
        });

        modelBuilder.Entity<SocialMedium>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("social_media");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Name).HasMaxLength(45);
            entity.Property(e => e.Sudo).HasMaxLength(45);
            entity.Property(e => e.Url)
                .HasMaxLength(100)
                .HasColumnName("URL");
        });

        modelBuilder.Entity<SocialProfil>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("social profil");

            entity.HasIndex(e => e.SocialMediaId, "fk_Social Profil_Social Media1_idx");

            entity.HasIndex(e => e.ContactId, "fk_Social Profil_contact_idx");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.ContactId)
                .HasColumnType("int(11)")
                .HasColumnName("contact_id");
            entity.Property(e => e.SocialMediaId)
                .HasColumnType("int(11)")
                .HasColumnName("Social Media_id");

            entity.HasOne(d => d.Contact).WithMany(p => p.SocialProfils)
                .HasForeignKey(d => d.ContactId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Social Profil_contact");

            entity.HasOne(d => d.SocialMedia).WithMany(p => p.SocialProfils)
                .HasForeignKey(d => d.SocialMediaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Social Profil_Social Media1");
        });

        modelBuilder.Entity<Tache>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Tache");

            entity.HasIndex(e => e.ToDoListId, "fk_Task_TO_DO_LIST1_idx");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.Etat).HasColumnType("enum('Faite','Pas Faite')");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");
            entity.Property(e => e.ToDoListId)
                .HasColumnType("int(11)")
                .HasColumnName("TO_DO_LIST_ID");

            entity.HasOne(d => d.ToDoList).WithMany(p => p.Taches)
                .HasForeignKey(d => d.ToDoListId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Task_TO_DO_LIST1");
        });

        modelBuilder.Entity<ToDoList>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("to_do_list");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.Description).HasMaxLength(45);
            entity.Property(e => e.EndDate).HasColumnName("End_Date");
            entity.Property(e => e.Titre).HasMaxLength(45);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
