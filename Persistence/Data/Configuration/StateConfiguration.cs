using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class StateConfiguration : IEntityTypeConfiguration<State>
    {
<<<<<<< HEAD
<<<<<<< HEAD
        public void Configure(EntityTypeBuilder<State> entity)
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("state");

            entity.HasIndex(e => e.IdCountryFk, "Fk_IdCountry");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");

            entity.HasOne(d => d.IdCountryFkNavigation).WithMany(p => p.States)
=======
=======
>>>>>>> ce41551957fea3c94be6e3bf99403f9e4982f068
        public void Configure(EntityTypeBuilder<State> builder)
        {
            builder.ToTable("state");

            builder.HasIndex(e => e.IdCountryFk, "Fk_IdCountry");

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");

            builder.HasOne(d => d.IdCountryFkNavigation).WithMany(p => p.States)
<<<<<<< HEAD
>>>>>>> 6d8ff27 (feat: :construction: New entities and configurations)
=======
>>>>>>> ce41551957fea3c94be6e3bf99403f9e4982f068
                .HasForeignKey(d => d.IdCountryFk)
                .HasConstraintName("Fk_IdCountry");
        }
    }
}