using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class ProveedorConfiguration : IEntityTypeConfiguration<Proveedor>
    {
<<<<<<< HEAD
        public void Configure(EntityTypeBuilder<Proveedor> entity)
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("proveedor");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cellphone).HasColumnName("cellphone");
            entity.Property(e => e.DentificationArd).HasColumnName("dentification_ard");
            entity.Property(e => e.Name)
=======
        public void Configure(EntityTypeBuilder<Proveedor> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("provider");

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.Cellphone).HasColumnName("cellphone");
            builder.Property(e => e.DentificationArd).HasColumnName("dentification_ard");
            builder.Property(e => e.Name)
>>>>>>> 6d8ff27 (feat: :construction: New entities and configurations)
                .HasMaxLength(50)
                .HasColumnName("name");
        }
    }
}