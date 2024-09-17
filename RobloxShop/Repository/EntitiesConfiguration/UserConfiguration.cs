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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            builder.Property(p => p.Name).HasMaxLength(200);

            builder.Property(p => p.Surname).HasMaxLength(200);

            builder.Property(p => p.Login).HasMaxLength(100);

            builder.Property(p => p.PasswordHash).HasMaxLength(256);
        }
    }
}
