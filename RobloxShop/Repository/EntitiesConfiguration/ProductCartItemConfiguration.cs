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
    public class ProductCartItemConfiguration : IEntityTypeConfiguration<ProductCartItem>
    {
        public void Configure(EntityTypeBuilder<ProductCartItem> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            builder.HasOne(pci => pci.Product).WithMany().HasForeignKey(pci => pci.ProductId);

            builder.HasOne(pci => pci.ProductCart).WithMany().HasForeignKey(pci => pci.ProductCartId);
        }
    }
}
