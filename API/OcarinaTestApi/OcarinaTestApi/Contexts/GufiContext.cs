using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OcarinaTestApi.Domains;

namespace OcarinaTestApi.Contexts;

public partial class GufiContext : DbContext
{
    public GufiContext()
    {
    }

    public GufiContext(DbContextOptions<GufiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Exercise> Exercises { get; set; }

    public virtual DbSet<TypeUser> TypeUsers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=FUCKINPC\\SQLEXPRESS; Initial Catalog=OcarinaTest; user Id=sa; pwd=teste; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Exercise>(entity =>
        {
            entity.HasKey(e => e.IdExercise).HasName("PK__Exercise__B33DF81851AB693A");

            entity.ToTable("Exercise");

            entity.Property(e => e.Finished).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);

          
        });

        modelBuilder.Entity<TypeUser>(entity =>
        {
            entity.HasKey(e => e.IdTypeUser).HasName("PK__TypeUser__4A0353C7F98620AA");

            entity.Property(e => e.Role)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("PK__Users__B7C92638C791ED51");

            entity.HasIndex(e => e.Email, "UQ__Users__A9D105345AE7DD71").IsUnique();

            entity.Property(e => e.CaloriesDay)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(35)
                .IsUnicode(false);

           
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
