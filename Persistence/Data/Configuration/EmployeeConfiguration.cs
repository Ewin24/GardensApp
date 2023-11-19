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
                .HasForeignKey(d => d.IdBossFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_IdBossFk");

            entity.HasOne(d => d.OfficeCodeNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.OfficeCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_OfficeCodeFk");
        }
    }
}