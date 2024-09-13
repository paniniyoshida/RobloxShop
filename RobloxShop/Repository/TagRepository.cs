using Microsoft.EntityFrameworkCore.ChangeTracking;
using RobloxShop.Entities;
using RobloxShop.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobloxShop.Repository
{
    public class TagRepository : ITagRepository
    {
        public Tag Add(Tag entity)
        {
            using ShopContext shopContext = new ShopContext();

            EntityEntry<Tag> addedEntity = shopContext.Tags.Add(entity);

            shopContext.SaveChanges();

            return addedEntity.Entity;
        }

        public void Delete(int id)
        {
            using ShopContext shopContext = new ShopContext();

            Tag tag = new Tag()
            {
                Id = id
            };

            shopContext.Tags.Remove(tag);

            shopContext.SaveChanges();
        }

        public Tag Get(int id)
        {
            using ShopContext shopContext = new ShopContext();
            return shopContext.Tags.FirstOrDefault(t => t.Id == id);
        }

        public List<Tag> GetAll()
        {
            using ShopContext shopContext = new ShopContext();
            return shopContext.Tags.ToList();
        }

        public Tag Update(Tag entity)
        {
            using ShopContext shopContext = new ShopContext();

            EntityEntry<Tag> updatedEntity = shopContext.Tags.Update(entity);

            shopContext.SaveChanges();

            return updatedEntity.Entity;
        }
    }
}
