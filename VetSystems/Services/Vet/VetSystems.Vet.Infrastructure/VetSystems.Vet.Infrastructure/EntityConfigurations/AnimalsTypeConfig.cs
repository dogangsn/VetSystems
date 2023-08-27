﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetSystems.Vet.Domain.Entities;

namespace VetSystems.Vet.Infrastructure.EntityConfigurations
{
    public class AnimalsTypeConfig : IEntityTypeConfiguration<VetAnimalsType>
    {
        public void Configure(EntityTypeBuilder<VetAnimalsType> entity)
        {
            entity.HasKey(e => e.Id)
                    .HasName("VetAnimalsType_pkey");

            entity.Property(e => e.Id)
                    .HasColumnName("Id")
                    .UseIdentityColumn();

        }
    }
}
