using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
<<<<<<< HEAD
<<<<<<< HEAD
        public void Configure(EntityTypeBuilder<Employee> entity)
        {
            entity.HasKey(e => e.EmployeeCode).HasName("PRIMARY");

            entity.ToTable("employee");

            entity.HasIndex(e => e.IdBossFk, "Fk_IdBossFk");

            entity.HasIndex(e => e.OfficeCode, "Fk_OfficeCodeFk");

            entity.Property(e => e.EmployeeCode)
                .ValueGeneratedNever()
                .HasColumnName("employee_code");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Extension)
                .HasMaxLength(10)
                .HasColumnName("extension");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName1)
                .HasMaxLength(50)
                .HasColumnName("last_name1");
            entity.Property(e => e.LastName2)
                .HasMaxLength(50)
                .HasColumnName("last_name2");
            entity.Property(e => e.OfficeCode)
                .HasMaxLength(10)
                .HasColumnName("office_code");
            entity.Property(e => e.Position)
                .HasMaxLength(50)
                .HasColumnName("position");

            entity.HasOne(d => d.IdBossFkNavigation).WithMany(p => p.Employees)
=======
=======
>>>>>>> ce41551957fea3c94be6e3bf99403f9e4982f068
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("employee");

            builder.HasIndex(e => e.IdBossFk, "Fk_IdBossFk");

            builder.HasIndex(e => e.OfficeCode, "Fk_OfficeCodeFk");

            builder.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("employee_code");
            builder.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            builder.Property(e => e.Extension)
                .HasMaxLength(10)
                .HasColumnName("extension");
            builder.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("first_name");
            builder.Property(e => e.LastName1)
                .HasMaxLength(50)
                .HasColumnName("last_name1");
            builder.Property(e => e.LastName2)
                .HasMaxLength(50)
                .HasColumnName("last_name2");
            builder.Property(e => e.OfficeCode)
                .HasMaxLength(10)
                .HasColumnName("office_code");
            builder.Property(e => e.Position)
                .HasMaxLength(50)
                .HasColumnName("position");

            builder.HasOne(d => d.IdBossFkNavigation).WithMany(p => p.Employees)
<<<<<<< HEAD
>>>>>>> 6d8ff27 (feat: :construction: New entities and configurations)
=======
>>>>>>> ce41551957fea3c94be6e3bf99403f9e4982f068
                .HasForeignKey(d => d.IdBossFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_IdBossFk");

<<<<<<< HEAD
            entity.HasOne(d => d.OfficeCodeNavigation).WithMany(p => p.Employees)
=======
            builder.HasOne(d => d.OfficeCodeNavigation).WithMany(p => p.Employees)
<<<<<<< HEAD
>>>>>>> 6d8ff27 (feat: :construction: New entities and configurations)
=======
>>>>>>> origin/main
>>>>>>> ce41551957fea3c94be6e3bf99403f9e4982f068
                .HasForeignKey(d => d.OfficeCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_OfficeCodeFk");
        }
    }
}