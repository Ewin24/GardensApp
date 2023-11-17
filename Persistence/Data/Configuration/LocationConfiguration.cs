using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class LocationConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> entity)
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("location");

            entity.HasIndex(e => e.IdClientFk, "Fk1_idClientFk");

            entity.HasIndex(e => e.IdCityFk, "Fk2_idCityFk");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Bis)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("bis");
            entity.Property(e => e.Cardinal)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("cardinal");
            entity.Property(e => e.CardinalSec)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("cardinalSec");
            entity.Property(e => e.Complemento)
                .HasMaxLength(50)
                .HasColumnName("complemento");
            entity.Property(e => e.IdCityFk).HasColumnName("idCityFk");
            entity.Property(e => e.IdClientFk).HasColumnName("idClientFk");
            entity.Property(e => e.Letra)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("letra");
            entity.Property(e => e.Letrasec)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("letrasec");
            entity.Property(e => e.Letrater)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("letrater");
            entity.Property(e => e.NumeroPri).HasColumnName("numeroPri");
            entity.Property(e => e.NumeroSec).HasColumnName("numeroSec");
            entity.Property(e => e.NumeroTer).HasColumnName("numeroTer");
            entity.Property(e => e.PostCode).HasMaxLength(10);
            entity.Property(e => e.TipoDeVia)
                .HasMaxLength(50)
                .HasColumnName("tipoDeVia");

            entity.HasOne(d => d.IdCityFkNavigation).WithMany(p => p.Locations)
                .HasForeignKey(d => d.IdCityFk)
                .HasConstraintName("Fk2_idCityFk");

            entity.HasOne(d => d.IdClientFkNavigation).WithMany(p => p.Locations)
                .HasForeignKey(d => d.IdClientFk)
                .HasConstraintName("Fk1_idClientFk");
        }
    }
}