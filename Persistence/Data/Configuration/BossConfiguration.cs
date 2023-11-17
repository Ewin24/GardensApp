using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class BossConfiguration : IEntityTypeConfiguration<Boss>
    {
        public void Configure(EntityTypeBuilder<Boss> entity)
        {

            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("boss");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cellphone).HasColumnName("cellphone");
            entity.Property(e => e.DentificationArd).HasColumnName("dentification_ard");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        }

    }
}
