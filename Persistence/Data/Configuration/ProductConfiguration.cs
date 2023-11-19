using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
<<<<<<< HEAD
        public void Configure(EntityTypeBuilder<Product> entity)
        {
            entity.HasKey(e => e.ProductCode).HasName("PRIMARY");

            entity.ToTable("product");

            entity.HasIndex(e => e.IdProveedorFk, "Fk_IdProveedorFk");

            entity.HasIndex(e => e.ProductLine, "Fk_product_line");

            entity.Property(e => e.ProductCode)
                .HasMaxLength(15)
                .HasColumnName("product_code");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Dimensions)
                .HasMaxLength(25)
                .HasColumnName("dimensions");
            entity.Property(e => e.Name)
                .HasMaxLength(70)
                .HasColumnName("name");
            entity.Property(e => e.ProductLine)
                .HasMaxLength(50)
                .HasColumnName("product_line");
            entity.Property(e => e.SellingPrice)
                .HasPrecision(15, 2)
                .HasColumnName("selling_price");
            entity.Property(e => e.StockQuantity).HasColumnName("stock_quantity");
            entity.Property(e => e.Supplier)
                .HasMaxLength(50)
                .HasColumnName("supplier");
            entity.Property(e => e.SupplierPrice)
                .HasPrecision(15, 2)
                .HasColumnName("supplier_price");

            entity.HasOne(d => d.IdProveedorFkNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdProveedorFk)
                .HasConstraintName("Fk_IdProveedorFk");

            entity.HasOne(d => d.ProductLineNavigation).WithMany(p => p.Products)
=======
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("product");

            builder.HasIndex(e => e.IdProviderFk, "Fk_IdproviderFk");

            builder.HasIndex(e => e.ProductLine, "Fk_product_line");

            builder.Property(e => e.ProductCode)
                .HasMaxLength(15)
                .HasColumnName("product_code");
            builder.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            builder.Property(e => e.Dimensions)
                .HasMaxLength(25)
                .HasColumnName("dimensions");
            builder.Property(e => e.Name)
                .HasMaxLength(70)
                .HasColumnName("name");
            builder.Property(e => e.ProductLine)
                .HasMaxLength(50)
                .HasColumnName("product_line");
            builder.Property(e => e.SellingPrice)
                .HasPrecision(15, 2)
                .HasColumnName("selling_price");
            builder.Property(e => e.StockQuantity).HasColumnName("stock_quantity");
            builder.Property(e => e.Supplier)
                .HasMaxLength(50)
                .HasColumnName("supplier");
            builder.Property(e => e.SupplierPrice)
                .HasPrecision(15, 2)
                .HasColumnName("supplier_price");

            builder.HasOne(d => d.IdProviderFkNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdProviderFk)
                .HasConstraintName("Fk_IdproviderFk");

            builder.HasOne(d => d.ProductLineNavigation).WithMany(p => p.Products)
>>>>>>> 6d8ff27 (feat: :construction: New entities and configurations)
                .HasForeignKey(d => d.ProductLine)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_product_line");
        }
    }
}