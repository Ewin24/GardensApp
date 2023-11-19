using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

<<<<<<< HEAD
namespace Persistence.Data.Configuration
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> entity)
        {
           entity.HasKey(e => e.TransactionId).HasName("PRIMARY");

            entity.ToTable("payment");

            entity.HasIndex(e => e.ClientCode, "Fk_cliente_code");

            entity.Property(e => e.TransactionId)
                .HasMaxLength(50)
                .HasColumnName("transaction_id");
            entity.Property(e => e.ClientCode).HasColumnName("client_code");
            entity.Property(e => e.PaymentDate).HasColumnName("payment_date");
            entity.Property(e => e.PaymentMethod)
                .HasMaxLength(40)
                .HasColumnName("payment_method");
            entity.Property(e => e.Total)
                .HasPrecision(15, 2)
                .HasColumnName("total");

            entity.HasOne(d => d.ClientCodeNavigation).WithMany(p => p.Payments)
                .HasForeignKey(d => d.ClientCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_cliente_code");
        }
    }
}
=======
namespace Persistence.Data.Configuration;

public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.ToTable("payment");

        builder.HasIndex(e => e.ClientCode, "Fk_cliente_code");

        builder.Property(e => e.TransactionId)
            .HasMaxLength(50)
            .HasColumnName("transaction_id");
        builder.Property(e => e.ClientCode).HasColumnName("client_code");
        builder.Property(e => e.PaymentDate).HasColumnName("payment_date");
        builder.Property(e => e.PaymentMethod)
            .HasMaxLength(40)
            .HasColumnName("payment_method");
        builder.Property(e => e.Total)
            .HasPrecision(15, 2)
            .HasColumnName("total");

        builder.HasOne(d => d.ClientCodeNavigation).WithMany(p => p.Payments)
            .HasForeignKey(d => d.ClientCode)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("Fk_cliente_code");
    }
}
>>>>>>> 6d8ff27 (feat: :construction: New entities and configurations)
