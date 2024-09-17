using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RobloxShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobloxShop.Repository.EntitiesConfiguration
{
    public class PromocodeConfiguration : IEntityTypeConfiguration<Promocode>
    {
        public void Configure(EntityTypeBuilder<Promocode> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            builder.Property(p => p.Name).HasMaxLength(200);

            builder.Property(p => p.Code).HasMaxLength(100);
        }
    }
}
