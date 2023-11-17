using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order>entity)
        {
            entity.HasKey(e => e.OrderCode).HasName("PRIMARY");

            entity.ToTable("orders");

            entity.HasIndex(e => e.ClientCode, "Fk_client_code");

            entity.Property(e => e.OrderCode)
                .ValueGeneratedNever()
                .HasColumnName("order_code");
            entity.Property(e => e.ClientCode).HasColumnName("client_code");
            entity.Property(e => e.Comments)
                .HasColumnType("text")
                .HasColumnName("comments");
            entity.Property(e => e.DeliveryDate).HasColumnName("delivery_date");
            entity.Property(e => e.ExpectedDate).HasColumnName("expected_date");
            entity.Property(e => e.OrderDate).HasColumnName("order_date");
            entity.Property(e => e.Status)
                .HasMaxLength(15)
                .HasColumnName("status");

            entity.HasOne(d => d.ClientCodeNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ClientCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_client_code");
        }
    }
}