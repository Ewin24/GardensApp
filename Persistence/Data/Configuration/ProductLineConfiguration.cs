using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class ProductLineConfiguration : IEntityTypeConfiguration<ProductLine>
    {
        public void Configure(EntityTypeBuilder<ProductLine> entity)
        {
            entity.HasKey(e => e.ProductLine1).HasName("PRIMARY");

            entity.ToTable("product_line");

            entity.Property(e => e.ProductLine1)
                .HasMaxLength(50)
                .HasColumnName("product_line");
            entity.Property(e => e.DescriptionHtml)
                .HasColumnType("text")
                .HasColumnName("description_html");
            entity.Property(e => e.DescriptionText)
                .HasColumnType("text")
                .HasColumnName("description_text");
            entity.Property(e => e.Image)
                .HasMaxLength(256)
                .HasColumnName("image");
        }
    }
}