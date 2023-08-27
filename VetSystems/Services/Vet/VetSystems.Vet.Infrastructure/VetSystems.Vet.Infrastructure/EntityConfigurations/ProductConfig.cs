﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetSystems.Vet.Domain.Entities;


namespace VetSystems.Vet.Infrastructure.EntityConfigurations
{
    public class ProductConfig : IEntityTypeConfiguration<VetProducts>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<VetProducts> entity)
        {
            entity.HasKey(e => e.Id)
                            .HasName("Vetproducts_pkey");
        }
    }
}
