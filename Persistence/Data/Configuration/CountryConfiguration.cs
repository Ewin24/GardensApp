using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
<<<<<<< HEAD
        public void Configure(EntityTypeBuilder<Country> entity)
        {
             entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("country");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
=======
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("country");

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.Name)
>>>>>>> 6d8ff27 (feat: :construction: New entities and configurations)
                .HasMaxLength(50)
                .HasColumnName("name");
        }
    }
}