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
    public class CheckPositionConfiguration : IEntityTypeConfiguration<CheckPosition>
    {
        public void Configure(EntityTypeBuilder<CheckPosition> builder)
        {
            builder.HasKey(cp => cp.Id);

            builder.Property(cp => cp.Id).ValueGeneratedOnAdd();

            builder.HasOne(cp => cp.Product).WithMany().HasForeignKey(cp => cp.ProductID);
        }
    }
}
