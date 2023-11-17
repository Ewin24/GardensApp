using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> entity)
        {
            entity.HasKey(e => e.ClientCode).HasName("PRIMARY");

            entity.ToTable("client");

            entity.HasIndex(e => e.IdContactFk, "FK_Contact");

            entity.HasIndex(e => e.IdEmployeeFk, "FK_Employee_FK");

            entity.Property(e => e.ClientCode)
                .ValueGeneratedNever()
                .HasColumnName("client_code");
            entity.Property(e => e.ClientName)
                .HasMaxLength(50)
                .HasColumnName("client_name");
            entity.Property(e => e.CreditLimit)
                .HasPrecision(15, 2)
                .HasColumnName("credit_limit");
            entity.Property(e => e.IdContactFk).HasColumnName("IdContactFK");
            entity.Property(e => e.IdEmployeeFk).HasColumnName("IdEmployeeFK");

            entity.HasOne(d => d.IdContactFkNavigation).WithMany(p => p.Clients)
                .HasForeignKey(d => d.IdContactFk)
                .HasConstraintName("FK_Contact");

            entity.HasOne(d => d.IdEmployeeFkNavigation).WithMany(p => p.Clients)
                .HasForeignKey(d => d.IdEmployeeFk)
                .HasConstraintName("FK_Employee_FK");
        }
    }
}