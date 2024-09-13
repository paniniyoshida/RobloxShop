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
    public class CheckConfiguration : IEntityTypeConfiguration<Check>
    {
        public void Configure(EntityTypeBuilder<Check> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            builder.HasOne(c => c.User).WithMany().HasForeignKey(c => c.UserID);

            builder.HasMany(c => c.CheckPositions).WithOne(cp => cp.Check).HasForeignKey(cp => cp.CheckID);

            builder.HasOne(c => c.Promocode).WithMany().HasForeignKey(cp => cp.PromocodeID);
        }
    }
}
