using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class TypeContactConfiguration : IEntityTypeConfiguration<TypeContact>
    {
        public void Configure(EntityTypeBuilder<TypeContact> entity)
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("type_contact");

            entity.HasIndex(e => e.IdContactFk, "Fk_IdContactFk");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.TypeContact1)
                .HasMaxLength(50)
                .HasColumnName("type_contact");

            entity.HasOne(d => d.IdContactFkNavigation).WithMany(p => p.TypeContacts)
                .HasForeignKey(d => d.IdContactFk)
                .HasConstraintName("Fk_IdContactFk");
        }
    }
}