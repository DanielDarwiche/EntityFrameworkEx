using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EntityFrameworkEx
{
    public partial class SkolaContext : DbContext
    {
        public SkolaContext()
        {
        }

        public SkolaContext(DbContextOptions<SkolaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<GradeRecord> GradeRecords { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<staff> staff { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
 
                optionsBuilder.UseSqlServer("Data Source = LAPTOP-KCRC8BJ8 ; Initial Catalog = Skola; \nIntegrated Security = True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GradeRecord>(entity =>
            {
                entity.HasKey(e => e.GradeId)
                    .HasName("PK__GradeRec__54F87A375908D510");

                entity.Property(e => e.GradeId).HasColumnName("GradeID");

                entity.Property(e => e.GradeName).HasMaxLength(50);

                entity.Property(e => e.GradeSetDate).HasColumnType("date");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.Property(e => e.TeacherId).HasColumnName("TeacherID");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.GradeRecords)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("StudentGRADES_FK");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.GradeRecords)
                    .HasForeignKey(d => d.TeacherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("StaffGRADES_FK");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.PersonalNumber)
                    .HasName("PK__Student__AC2CC42F6F2A1B63");

                entity.ToTable("Student");

                entity.Property(e => e.Class)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('Biology')");

                entity.Property(e => e.StudentLastName)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('Andersson')");

                entity.Property(e => e.StudentName).HasMaxLength(50);
            });

            modelBuilder.Entity<staff>(entity =>
            {
                entity.HasKey(e => e.PersonalNumber)
                    .HasName("PK__Staff__AC2CC42FA0D817A4");

                entity.ToTable("Staff");

                entity.Property(e => e.StaffName).HasMaxLength(50);

                entity.Property(e => e.StaffRole).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
