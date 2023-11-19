using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> entity)
        {
             entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("contact");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.ContactLastName)
                .HasMaxLength(30)
                .HasColumnName("contact_last_name");
            entity.Property(e => e.ContactName)
                .HasMaxLength(30)
                .HasColumnName("contact_name");
            entity.Property(e => e.ContactNumbrer)
                .HasMaxLength(15)
                .HasColumnName("contact_numbrer");
            entity.Property(e => e.Fax)
                .HasMaxLength(15)
                .HasColumnName("fax");
        }
    }
}