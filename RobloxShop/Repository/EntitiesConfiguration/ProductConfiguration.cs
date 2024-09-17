using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RobloxShop.Entities;
using RobloxShop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobloxShop.Repository.EntitiesConfiguration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            builder.Property(p => p.Name).HasMaxLength(200);

            builder.Property(p => p.Description).HasMaxLength(1000);

            builder.HasOne(p => p.Category).WithMany().HasForeignKey(p => p.CategoryID);

            builder.HasMany(p => p.Tags).WithMany();
        }
    }
}
