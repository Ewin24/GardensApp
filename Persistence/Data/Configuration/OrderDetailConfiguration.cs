using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> entity)
        {
             entity.HasKey(e => new { e.OrderCode, e.ProductCode })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("order_detail");

            entity.HasIndex(e => e.ProductCode, "Fk2_product_code");

            entity.Property(e => e.OrderCode).HasColumnName("order_code");
            entity.Property(e => e.ProductCode)
                .HasMaxLength(15)
                .HasColumnName("product_code");
            entity.Property(e => e.LineNumber).HasColumnName("line_number");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.UnitPrice)
                .HasPrecision(15, 2)
                .HasColumnName("unit_price");

            entity.HasOne(d => d.OrderCodeNavigation).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk1_order_code");

            entity.HasOne(d => d.ProductCodeNavigation).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.ProductCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk2_product_code");
        }
    }
}