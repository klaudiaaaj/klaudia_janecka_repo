using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DanceSchool_10._05_ASP.NET_MVC.mydb
{
    public partial class mydbContext : DbContext // The Entity Framework Core DbContext class represents a session with a database and provides an API for communicating with •the database with the following capabilities:
    {
        public mydbContext()
        {
        }

        public mydbContext(DbContextOptions<mydbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Class> Class { get; set; }
        public virtual DbSet<Classroom> Classroom { get; set; }
        public virtual DbSet<DanceStyle> DanceStyle { get; set; }
        public virtual DbSet<Dancer> Dancer { get; set; }
        public virtual DbSet<Function> Function { get; set; }
        public virtual DbSet<Group> Group { get; set; }
        public virtual DbSet<GroupEnrollments> GroupEnrollments { get; set; }
        public virtual DbSet<GroupHasDancer> GroupHasDancer { get; set; }
        public virtual DbSet<SoloEnrollments> SoloEnrollments { get; set; }
        public virtual DbSet<TurnamentGroup> TurnamentGroup { get; set; }
        public virtual DbSet<TurnamentSolo> TurnamentSolo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=DpVeR6UX;database=mydb");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Class>(entity =>
            {
                entity.ToTable("class");

                entity.HasIndex(e => e.ClassroomId)
                    .HasName("fk_Class_Classroom1_idx");

                entity.HasIndex(e => e.GroupId)
                    .HasName("fk_Class_Group1_idx");

                entity.Property(e => e.ClassId).HasColumnName("class_id");

                entity.Property(e => e.ClassroomId).HasColumnName("classroom_id");

                entity.Property(e => e.DancestyleId)
                    .IsRequired()
                    .HasColumnName("dancestyle_id")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.End).HasColumnName("end");

                entity.Property(e => e.GroupId).HasColumnName("group_id");

                entity.Property(e => e.Long).HasColumnName("long");

                entity.Property(e => e.Start).HasColumnName("start");

                entity.Property(e => e.Weekday).HasColumnName("weekday");

                entity.HasOne(d => d.Classroom)
                    .WithMany(p => p.Class)
                    .HasForeignKey(d => d.ClassroomId)
                    .HasConstraintName("fk_Class_Classroom1");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Class)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Class_Group1");
            });

            modelBuilder.Entity<Classroom>(entity =>
            {
                entity.ToTable("classroom");

                entity.Property(e => e.ClassroomId).HasColumnName("classroom_id");

                entity.Property(e => e.Free)
                    .HasColumnName("free")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.Hour).HasColumnName("hour");

                entity.Property(e => e.Weekday).HasColumnName("weekday");
            });

            modelBuilder.Entity<DanceStyle>(entity =>
            {
                entity.ToTable("dance_style");

                entity.Property(e => e.DancestyleId).HasColumnName("dancestyle_id");

                entity.Property(e => e.DancestyleName)
                    .HasColumnName("dancestyle_name")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Dancer>(entity =>
            {
                entity.ToTable("dancer");

                entity.HasIndex(e => e.DancerId)
                    .HasName("dancer_id_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.FunctionId)
                    .HasName("fk_Dancer_Function1_idx");

                entity.Property(e => e.DancerId).HasColumnName("dancer_id");

                entity.Property(e => e.FunctionFunctionId).HasColumnName("Function_function_id");

                entity.Property(e => e.FunctionId).HasColumnName("function_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasColumnName("surname")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.Function)
                    .WithMany(p => p.Dancer)
                    .HasForeignKey(d => d.FunctionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Dancer_Function1");
            });

            modelBuilder.Entity<Function>(entity =>
            {
                entity.ToTable("function");

                entity.Property(e => e.FunctionId).HasColumnName("function_id");

                entity.Property(e => e.FunctionName)
                    .HasColumnName("function_name")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.ToTable("group");

                entity.HasIndex(e => e.DancestyleId)
                    .HasName("fk_Group_Dance_style1_idx");

                entity.HasIndex(e => e.GroupId)
                    .HasName("group_id_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.GroupName)
                    .HasName("group_name_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.GroupId).HasColumnName("group_id");

                entity.Property(e => e.DancestyleId).HasColumnName("dancestyle_id");

                entity.Property(e => e.GroupName)
                    .IsRequired()
                    .HasColumnName("group_name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Supervisor)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.Dancestyle)
                    .WithMany(p => p.Group)
                    .HasForeignKey(d => d.DancestyleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Group_Dance_style1");
            });

            modelBuilder.Entity<GroupEnrollments>(entity =>
            {
                entity.HasKey(e => new { e.TurnamentGroupId, e.GroupId })
                    .HasName("PRIMARY");

                entity.ToTable("group_enrollments");

                entity.HasIndex(e => e.GroupId)
                    .HasName("group_id_idx");

                entity.Property(e => e.TurnamentGroupId).HasColumnName("turnament_group_id");

                entity.Property(e => e.GroupId).HasColumnName("group_id");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.GroupEnrollments)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("group_id");
            });

            modelBuilder.Entity<GroupHasDancer>(entity =>
            {
                entity.HasKey(e => new { e.GroupGroupId, e.DancerDancerId })
                    .HasName("PRIMARY");

                entity.ToTable("group_has_dancer");

                entity.HasIndex(e => e.DancerDancerId)
                    .HasName("fk_Group_has_Dancer_Dancer1_idx");

                entity.HasIndex(e => e.GroupGroupId)
                    .HasName("fk_Group_has_Dancer_Group1_idx");

                entity.Property(e => e.GroupGroupId).HasColumnName("Group_group_id");

                entity.Property(e => e.DancerDancerId).HasColumnName("Dancer_dancer_id");

                entity.HasOne(d => d.DancerDancer)
                    .WithMany(p => p.GroupHasDancer)
                    .HasForeignKey(d => d.DancerDancerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Group_has_Dancer_Dancer1");

                entity.HasOne(d => d.GroupGroup)
                    .WithMany(p => p.GroupHasDancer)
                    .HasForeignKey(d => d.GroupGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Group_has_Dancer_Group1");
            });

            modelBuilder.Entity<SoloEnrollments>(entity =>
            {
                entity.HasKey(e => new { e.DancerId, e.TurnamentSoloId })
                    .HasName("PRIMARY");

                entity.ToTable("solo_enrollments");

                entity.HasIndex(e => e.DancerId)
                    .HasName("fk_Dancer_has_Turnament_solo_Dancer1_idx");

                entity.Property(e => e.DancerId).HasColumnName("dancer_id");

                entity.Property(e => e.TurnamentSoloId).HasColumnName("turnament_solo_id");

                entity.HasOne(d => d.Dancer)
                    .WithMany(p => p.SoloEnrollments)
                    .HasForeignKey(d => d.DancerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Dancer_has_Turnament_solo_Dancer1");
            });

            modelBuilder.Entity<TurnamentGroup>(entity =>
            {
                entity.HasKey(e => new { e.TurnamentGroupId, e.GroupId })
                    .HasName("PRIMARY");

                entity.ToTable("turnament_group");

                entity.Property(e => e.TurnamentGroupId).HasColumnName("turnament_group_id");

                entity.Property(e => e.GroupId).HasColumnName("group_id");

                entity.Property(e => e.Aword)
                    .HasColumnName("aword")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.DancestyleId).HasColumnName("dancestyle_id");

                entity.Property(e => e.Data)
                    .HasColumnName("data")
                    .HasColumnType("date");

                entity.Property(e => e.Place).HasColumnName("place");

                entity.Property(e => e.TurnamentName)
                    .IsRequired()
                    .HasColumnName("turnament_name")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TurnamentSolo>(entity =>
            {
                entity.HasKey(e => new { e.TurnamentSoloId, e.DancerId })
                    .HasName("PRIMARY");

                entity.ToTable("turnament_solo");

                entity.HasIndex(e => new { e.DancerId, e.TurnamentSoloId })
                    .HasName("dancer_id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.TurnamentSoloId).HasColumnName("turnament_solo_id");

                entity.Property(e => e.DancerId).HasColumnName("dancer_id");

                entity.Property(e => e.Aword)
                    .HasColumnName("aword")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Data)
                    .HasColumnName("data")
                    .HasColumnType("date");

                entity.Property(e => e.Place).HasColumnName("place");

                entity.Property(e => e.TurnamentName)
                    .HasColumnName("turnament_name")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.SoloEnrollments)
                    .WithOne(p => p.TurnamentSolo)
                    .HasForeignKey<TurnamentSolo>(d => new { d.DancerId, d.TurnamentSoloId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("turnament_solo_id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
